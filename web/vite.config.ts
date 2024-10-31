/// <reference types="vite" />

import reactPlugin from '@vitejs/plugin-react';
import codegen from 'vite-plugin-graphql-codegen';
import tsconfigPathsPlugin from 'vite-tsconfig-paths';

// https://vitejs.dev/config/
const config = () => ({
  plugins: [tsconfigPathsPlugin(), reactPlugin(), codegen()],
  server: {
    port: 5173,
    proxy: {
      '/graphql': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        secure: false,
        ws: true,
      },
    },
  },

  css: {
    preprocessorOptions: {
      scss: {
        api: 'modern-compiler', // or "modern"
      },
    },
  },
});

export default config;
