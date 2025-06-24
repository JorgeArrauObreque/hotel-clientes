import type { Sequelize } from "sequelize";
import { ciudad as _ciudad } from "./ciudad";
import type { ciudadAttributes, ciudadCreationAttributes } from "./ciudad";
import { cliente_estado as _cliente_estado } from "./cliente_estado";
import type { cliente_estadoAttributes, cliente_estadoCreationAttributes } from "./cliente_estado";
import { cliente_nivel_membresia as _cliente_nivel_membresia } from "./cliente_nivel_membresia";
import type { cliente_nivel_membresiaAttributes, cliente_nivel_membresiaCreationAttributes } from "./cliente_nivel_membresia";
import { clientes as _clientes } from "./clientes";
import type { clientesAttributes, clientesCreationAttributes } from "./clientes";
import { comuna as _comuna } from "./comuna";
import type { comunaAttributes, comunaCreationAttributes } from "./comuna";

export {
  _ciudad as ciudad,
  _cliente_estado as cliente_estado,
  _cliente_nivel_membresia as cliente_nivel_membresia,
  _clientes as clientes,
  _comuna as comuna,
};

export type {
  ciudadAttributes,
  ciudadCreationAttributes,
  cliente_estadoAttributes,
  cliente_estadoCreationAttributes,
  cliente_nivel_membresiaAttributes,
  cliente_nivel_membresiaCreationAttributes,
  clientesAttributes,
  clientesCreationAttributes,
  comunaAttributes,
  comunaCreationAttributes,
};

export function initModels(sequelize: Sequelize) {
  const ciudad = _ciudad.initModel(sequelize);
  const cliente_estado = _cliente_estado.initModel(sequelize);
  const cliente_nivel_membresia = _cliente_nivel_membresia.initModel(sequelize);
  const clientes = _clientes.initModel(sequelize);
  const comuna = _comuna.initModel(sequelize);

  comuna.belongsTo(ciudad, { as: "id_ciudad_ciudad", foreignKey: "id_ciudad"});
  ciudad.hasMany(comuna, { as: "comunas", foreignKey: "id_ciudad"});
  clientes.belongsTo(cliente_nivel_membresia, { as: "id_nivel_membresia_cliente_nivel_membresium", foreignKey: "id_nivel_membresia"});
  cliente_nivel_membresia.hasMany(clientes, { as: "clientes", foreignKey: "id_nivel_membresia"});
  clientes.belongsTo(comuna, { as: "id_comuna_comuna", foreignKey: "id_comuna"});
  comuna.hasMany(clientes, { as: "clientes", foreignKey: "id_comuna"});

  return {
    ciudad: ciudad,
    cliente_estado: cliente_estado,
    cliente_nivel_membresia: cliente_nivel_membresia,
    clientes: clientes,
    comuna: comuna,
  };
}
