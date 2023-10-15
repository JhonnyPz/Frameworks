List<string> test = args.ToList();
if (test.IndexOf("-h") != -1)
{
  Console.WriteLine($"syntax: app.run ./path/name \n\naption: \n -max 0 \n -ignore 'bin, obj'\n");
  return;
}

try
{
  string dir = test.LastOrDefault(value => value.StartsWith(".")) ?? ".";
  string path = Path.GetFullPath(dir);

  string _max = test.IndexOf("-max") != -1 ? test[test.IndexOf("-max") + 1] : "0";
  int max = Convert.ToInt32(_max);

  string ignore = test.IndexOf("-ignore") != -1 ? test[test.IndexOf("-ignore") + 1] : "";

  Console.WriteLine($"dir:'{dir}' max:{max} path:'{path}'\n");
  TreeDir(new DirectoryInfo(path), max, ignore);
}
catch
{
  Console.ForegroundColor = ConsoleColor.Red;
  Console.Write($"syntax error: app.exe ./path/name or app.exe -h");
  Console.ResetColor();
}

static void TreeDir(DirectoryInfo dir, int max, string ignore, int level = 0)
{
  Console.ForegroundColor = ConsoleColor.Magenta;
  Console.WriteLine((level == 0) ? dir.Name + "/" : Prefix(level) + "├─ " + dir.Name + "/");
  Console.ResetColor();

  if (level > max) return;
  foreach (var file in dir.GetFiles())
  {
    Console.WriteLine(Prefix(level + 1) + "├─ " + file.Name);
  }

  foreach (var subDir in dir.GetDirectories())
  {
    if (!ignore.ToLower().Contains(subDir.Name.ToLower())) TreeDir(subDir, max, ignore, level + 1);
  }
}

static string Prefix(int level)
{
  string prefix = "";
  for (int i = 1; i < level; i++)
  {
    prefix += "│   ";
  }
  return prefix;
}