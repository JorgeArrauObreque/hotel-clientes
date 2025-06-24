import Express from "express";
import dotenv from "dotenv"
import { initModels } from "./src/models/init-models";
import { sequelize_clientes } from "./src/models/config/sequelize_clientes";
dotenv.config();

const app = Express();
initModels(sequelize_clientes);
app.listen(process.env.PORT,()=>{
    console.log(`listening on: ${process.env.PORT}`);
});