import React from 'react'
import ReactDOM from 'react-dom/client'
import './style/index.css'
import { CrudApp } from './CrudApp'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <CrudApp/>
  </React.StrictMode>,
)
