import { Sequelize } from 'sequelize';

export const sequelize_clientes = new Sequelize('FacturacionHotel', 'se', '123', {
  host: 'localhost',
  dialect: 'mssql',
  port: 1433,
  dialectOptions: {
    options: {
      encrypt: false, // Cambia a true si usas Azure
      trustServerCertificate: true, // útil para dev local
    },
  },
  logging: false,
});