import * as Sequelize from 'sequelize';
import { DataTypes, Model, Optional } from 'sequelize';
import type { clientes, clientesId } from './clientes';

export interface cliente_nivel_membresiaAttributes {
  id_cliente_membresia: number;
  descripcion_cliente_membresia: string;
}

export type cliente_nivel_membresiaPk = "id_cliente_membresia";
export type cliente_nivel_membresiaId = cliente_nivel_membresia[cliente_nivel_membresiaPk];
export type cliente_nivel_membresiaOptionalAttributes = "id_cliente_membresia";
export type cliente_nivel_membresiaCreationAttributes = Optional<cliente_nivel_membresiaAttributes, cliente_nivel_membresiaOptionalAttributes>;

export class cliente_nivel_membresia extends Model<cliente_nivel_membresiaAttributes, cliente_nivel_membresiaCreationAttributes> implements cliente_nivel_membresiaAttributes {
  id_cliente_membresia!: number;
  descripcion_cliente_membresia!: string;

  // cliente_nivel_membresia hasMany clientes via id_nivel_membresia
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

  static initModel(sequelize: Sequelize.Sequelize): typeof cliente_nivel_membresia {
    return cliente_nivel_membresia.init({
    id_cliente_membresia: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    descripcion_cliente_membresia: {
      type: DataTypes.STRING(80),
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'cliente_nivel_membresia',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_cliente_nivel_membresia",
        unique: true,
        fields: [
          { name: "id_cliente_membresia" },
        ]
      },
    ]
  });
  }
}
