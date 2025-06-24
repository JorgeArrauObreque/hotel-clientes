const dotenv = require('dotenv')

module.exports ={
  "host": "localhost",
  "database": "FacturacionHotel",
  "username": "se",
  "password": "123",
  "dialect": "mssql",
  "port": 1433,
  "tables": ['ciudad','comuna',"clientes","cliente_estado","cliente_nivel_membresia"],
  "dialectOptions": {
    "encrypt": false,
    "trustServerCertificate": true
  },
  "lang": "ts",
  "directory": "./src/models"
}
