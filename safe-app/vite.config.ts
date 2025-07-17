import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import basicSsl from '@vitejs/plugin-basic-ssl'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
      react(),
      basicSsl({
          name: "file-safe-ssl",
          certDir: "Cert/"
      })
  ],
    server: {
      port: 3000
    }
})
