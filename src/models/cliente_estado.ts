import * as Sequelize from 'sequelize';
import { DataTypes, Model, Optional } from 'sequelize';

export interface cliente_estadoAttributes {
  id_cliente_estado: number;
  descripcion_cliente_estado: string;
  fecha_ingreso: Date;
  fecha_actualizacion: Date;
}

export type cliente_estadoPk = "id_cliente_estado";
export type cliente_estadoId = cliente_estado[cliente_estadoPk];
export type cliente_estadoOptionalAttributes = "id_cliente_estado";
export type cliente_estadoCreationAttributes = Optional<cliente_estadoAttributes, cliente_estadoOptionalAttributes>;

export class cliente_estado extends Model<cliente_estadoAttributes, cliente_estadoCreationAttributes> implements cliente_estadoAttributes {
  id_cliente_estado!: number;
  descripcion_cliente_estado!: string;
  fecha_ingreso!: Date;
  fecha_actualizacion!: Date;


  static initModel(sequelize: Sequelize.Sequelize): typeof cliente_estado {
    return cliente_estado.init({
    id_cliente_estado: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    descripcion_cliente_estado: {
      type: DataTypes.STRING(80),
      allowNull: false
    },
    fecha_ingreso: {
      type: DataTypes.DATE,
      allowNull: false
    },
    fecha_actualizacion: {
      type: DataTypes.DATE,
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'cliente_estado',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_cliente_estado",
        unique: true,
        fields: [
          { name: "id_cliente_estado" },
        ]
      },
    ]
  });
  }
}
