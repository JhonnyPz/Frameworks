import { defineConfig } from 'astro/config';
import tailwind from '@astrojs/tailwind';
import node from "@astrojs/node";

// https://astro.build/config
export default defineConfig({
  integrations: [tailwind()],
  output: 'static', //'static','hybrid','server'
  adapter: node({
    mode: "standalone"
  })
});