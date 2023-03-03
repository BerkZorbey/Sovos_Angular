const PROXY_CONFIG = [
  {
    "context": [
      "/invoice"
    ],
    "target": "https://localhost:7032",
    "secure": false,
    "changeOrigin": true,
    "headers": {
      "Connection": 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
