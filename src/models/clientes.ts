import * as Sequelize from 'sequelize';
import { DataTypes, Model, Optional } from 'sequelize';
import type { cliente_nivel_membresia, cliente_nivel_membresiaId } from './cliente_nivel_membresia';
import type { comuna, comunaId } from './comuna';

export interface clientesAttributes {
  rut_cliente: string;
  nombres: string;
  apellidos: string;
  correo: string;
  telefono: string;
  fecha_creacion: Date;
  fecha_actualizacion: Date;
  estado: number;
  id_comuna: number;
  direccion: string;
  nacionalidad: string;
  genero: string;
  pais_origen: string;
  observaciones?: string;
  cliente_frecuente: boolean;
  creadopor: string;
  modificadopor: string;
  id_nivel_membresia?: number;
}

export type clientesPk = "rut_cliente";
export type clientesId = clientes[clientesPk];
export type clientesOptionalAttributes = "observaciones" | "id_nivel_membresia";
export type clientesCreationAttributes = Optional<clientesAttributes, clientesOptionalAttributes>;

export class clientes extends Model<clientesAttributes, clientesCreationAttributes> implements clientesAttributes {
  rut_cliente!: string;
  nombres!: string;
  apellidos!: string;
  correo!: string;
  telefono!: string;
  fecha_creacion!: Date;
  fecha_actualizacion!: Date;
  estado!: number;
  id_comuna!: number;
  direccion!: string;
  nacionalidad!: string;
  genero!: string;
  pais_origen!: string;
  observaciones?: string;
  cliente_frecuente!: boolean;
  creadopor!: string;
  modificadopor!: string;
  id_nivel_membresia?: number;

  // clientes belongsTo cliente_nivel_membresia via id_nivel_membresia
  id_nivel_membresia_cliente_nivel_membresium!: cliente_nivel_membresia;
  getId_nivel_membresia_cliente_nivel_membresium!: Sequelize.BelongsToGetAssociationMixin<cliente_nivel_membresia>;
  setId_nivel_membresia_cliente_nivel_membresium!: Sequelize.BelongsToSetAssociationMixin<cliente_nivel_membresia, cliente_nivel_membresiaId>;
  createId_nivel_membresia_cliente_nivel_membresium!: Sequelize.BelongsToCreateAssociationMixin<cliente_nivel_membresia>;
  // clientes belongsTo comuna via id_comuna
  id_comuna_comuna!: comuna;
  getId_comuna_comuna!: Sequelize.BelongsToGetAssociationMixin<comuna>;
  setId_comuna_comuna!: Sequelize.BelongsToSetAssociationMixin<comuna, comunaId>;
  createId_comuna_comuna!: Sequelize.BelongsToCreateAssociationMixin<comuna>;

  static initModel(sequelize: Sequelize.Sequelize): typeof clientes {
    return clientes.init({
    rut_cliente: {
      type: DataTypes.STRING(15),
      allowNull: false,
      primaryKey: true
    },
    nombres: {
      type: DataTypes.STRING(70),
      allowNull: false
    },
    apellidos: {
      type: DataTypes.STRING(70),
      allowNull: false
    },
    correo: {
      type: DataTypes.STRING(50),
      allowNull: false
    },
    telefono: {
      type: DataTypes.STRING(15),
      allowNull: false
    },
    fecha_creacion: {
      type: DataTypes.DATE,
      allowNull: false
    },
    fecha_actualizacion: {
      type: DataTypes.DATE,
      allowNull: false
    },
    estado: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    id_comuna: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'comuna',
        key: 'id_comuna'
      }
    },
    direccion: {
      type: DataTypes.STRING(200),
      allowNull: false
    },
    nacionalidad: {
      type: DataTypes.STRING(100),
      allowNull: false
    },
    genero: {
      type: DataTypes.CHAR(1),
      allowNull: false
    },
    pais_origen: {
      type: DataTypes.STRING(120),
      allowNull: false
    },
    observaciones: {
      type: DataTypes.STRING(250),
      allowNull: true
    },
    cliente_frecuente: {
      type: DataTypes.BOOLEAN,
      allowNull: false
    },
    creadopor: {
      type: DataTypes.STRING(100),
      allowNull: false
    },
    modificadopor: {
      type: DataTypes.STRING(100),
      allowNull: false
    },
    id_nivel_membresia: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'cliente_nivel_membresia',
        key: 'id_cliente_membresia'
      }
    }
  }, {
    sequelize,
    tableName: 'clientes',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_Empresas",
        unique: true,
        fields: [
          { name: "rut_cliente" },
        ]
      },
    ]
  });
  }
}
