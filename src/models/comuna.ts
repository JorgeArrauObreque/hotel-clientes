import * as Sequelize from 'sequelize';
import { DataTypes, Model, Optional } from 'sequelize';
import type { ciudad, ciudadId } from './ciudad';
import type { clientes, clientesId } from './clientes';

export interface comunaAttributes {
  id_comuna: number;
  nombre_comuna: string;
  id_ciudad: number;
}

export type comunaPk = "id_comuna";
export type comunaId = comuna[comunaPk];
export type comunaOptionalAttributes = "id_comuna";
export type comunaCreationAttributes = Optional<comunaAttributes, comunaOptionalAttributes>;

export class comuna extends Model<comunaAttributes, comunaCreationAttributes> implements comunaAttributes {
  id_comuna!: number;
  nombre_comuna!: string;
  id_ciudad!: number;

  // comuna belongsTo ciudad via id_ciudad
  id_ciudad_ciudad!: ciudad;
  getId_ciudad_ciudad!: Sequelize.BelongsToGetAssociationMixin<ciudad>;
  setId_ciudad_ciudad!: Sequelize.BelongsToSetAssociationMixin<ciudad, ciudadId>;
  createId_ciudad_ciudad!: Sequelize.BelongsToCreateAssociationMixin<ciudad>;
  // comuna hasMany clientes via id_comuna
  clientes!: clientes[];
  getClientes!: Sequelize.HasManyGetAssociationsMixin<clientes>;
  setClientes!: Sequelize.HasManySetAssociationsMixin<clientes, clientesId>;
  addCliente!: Sequelize.HasManyAddAssociationMixin<clientes, clientesId>;
  addClientes!: Sequelize.HasManyAddAssociationsMixin<clientes, clientesId>;
  createCliente!: Sequelize.HasManyCreateAssociationMixin<clientes>;
  removeCliente!: Sequelize.HasManyRemoveAssociationMixin<clientes, clientesId>;
  removeClientes!: Sequelize.HasManyRemoveAssociationsMixin<clientes, clientesId>;
  hasCliente!: Sequelize.HasManyHasAssociationMixin<clientes, clientesId>;
  hasClientes!: Sequelize.HasManyHasAssociationsMixin<clientes, clientesId>;
  countClientes!: Sequelize.HasManyCountAssociationsMixin;

  static initModel(sequelize: Sequelize.Sequelize): typeof comuna {
    return comuna.init({
    id_comuna: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    nombre_comuna: {
      type: DataTypes.STRING(90),
      allowNull: false
    },
    id_ciudad: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'ciudad',
        key: 'id_ciudad'
      }
    }
  }, {
    sequelize,
    tableName: 'comuna',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_comuna",
        unique: true,
        fields: [
          { name: "id_comuna" },
        ]
      },
    ]
  });
  }
}
