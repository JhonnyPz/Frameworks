const fs = require('node:fs/promises')
const path = require('node:path')
const pc = require('picocolors')

const folder = process.argv[2] ?? '.'

async function ls(folder) {
  let files
  try {
    files = await fs.readdir(folder)
  } catch {
    console.error(pc.red(`Error directory ${folder}`))
    process.exit(1)
  }

  const filePromises = files.map(async file => {
    const filePath = path.join(folder, file)
    let stats
    try {
      stats = await fs.stat(filePath)
    } catch {
      console.error(`Error file ${filePath}`)
      process.exit(1)
    }

    const isDirectory = stats.isDirectory()
    const fileType = isDirectory ? '-d---' : '-f---'
    const fileSize = stats.size.toString()
    const fileModifDate = stats.mtime.toLocaleDateString()
    const fileModifTime = stats.mtime.toLocaleTimeString()

    return `${pc.italic(fileType.padEnd(15))} ${pc.yellow(fileModifDate.padEnd(10))} ${pc.yellow(fileModifTime)} ${pc.green(fileSize.padStart(10))} ${pc.blue(file)}`
  })

  const filesInfo = await Promise.all(filePromises)
  filesInfo.forEach(fileInfo => console.log(fileInfo))
}

ls(folder)
