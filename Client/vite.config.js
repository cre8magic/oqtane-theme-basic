import { defineConfig } from 'vite';
import { resolve } from 'path';
import { viteStaticCopy } from 'vite-plugin-static-copy';
import autoprefixer from 'autoprefixer';
import fs from 'fs';

// The value below must match the `Theme.PackageName` property in ThemeInfo.cs
// This determines the output folder structure in wwwroot/Themes/ where static assets are stored
const packageName = 'ToSic.Cre8magic.Theme.Basic';
const distFolder = `wwwroot/Themes/${packageName}`;

// Export the Vite config, using a function to access the build mode (e.g., 'dev' or 'production')
export default defineConfig(({ mode }) => {
  const isDebug = (mode == 'dev'); // Set a flag for debug mode (true if running in 'dev' mode)
  return {
      build: {
      emptyOutDir: false,  // Do not empty the output directory before building (prevents deleting files outside Vite control)
      sourcemap: true, // Generate source maps for easier debugging
      minify: isDebug ? false : 'esbuild',  // Only minify in production (not in dev mode)
      cssCodeSplit: false, // Don't split CSS into multiple files (keeps output as a single stylesheet)
      outDir: distFolder, // Output directory for compiled assets
      rollupOptions: {
        input: {
          theme: './src/styles/styles.scss'  // Specify the entry point for the theme's SCSS
        },
        output: {
          // Rename the generated CSS file to 'styles.min.css'
          assetFileNames: (assetInfo) => {
            if (assetInfo.name === 'style.css')
                return 'styles.min.css';
            return '[name][extname]'; // Use default naming for any other assets
          },
        },
      },
    },

    css: {
      preprocessorOptions: {
        scss: {
          // Silence specific SCSS deprecation warnings
          silenceDeprecations: ['mixed-decls', 'color-functions', 'global-builtin', 'import']
        },
      },
      postcss: {
        // Use autoprefixer to add vendor prefixes automatically
        plugins: [autoprefixer()]
      },
    },

    // Vite plugins
    plugins: [
      viteStaticCopy({
        targets: [
          {
            // Copy all assets from ./src/assets and Bootstrap's bundled JS from node_modules
            src: ['./src/assets', './node_modules/bootstrap/dist/js/bootstrap.bundle.min.*'],
            dest: './'
          },
        ],
        // Run the copy after the bundle is written
        hook: 'writeBundle',
      }),
    ]
  };
});