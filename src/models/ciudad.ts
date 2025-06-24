import * as Sequelize from 'sequelize';
import { DataTypes, Model, Optional } from 'sequelize';
import type { comuna, comunaId } from './comuna';

export interface ciudadAttributes {
  id_ciudad: number;
  nombre_ciudad: string;
}

export type ciudadPk = "id_ciudad";
export type ciudadId = ciudad[ciudadPk];
export type ciudadOptionalAttributes = "id_ciudad";
export type ciudadCreationAttributes = Optional<ciudadAttributes, ciudadOptionalAttributes>;

export class ciudad extends Model<ciudadAttributes, ciudadCreationAttributes> implements ciudadAttributes {
  id_ciudad!: number;
  nombre_ciudad!: string;

  // ciudad hasMany comuna via id_ciudad
  comunas!: comuna[];
  getComunas!: Sequelize.HasManyGetAssociationsMixin<comuna>;
  setComunas!: Sequelize.HasManySetAssociationsMixin<comuna, comunaId>;
  addComuna!: Sequelize.HasManyAddAssociationMixin<comuna, comunaId>;
  addComunas!: Sequelize.HasManyAddAssociationsMixin<comuna, comunaId>;
  createComuna!: Sequelize.HasManyCreateAssociationMixin<comuna>;
  removeComuna!: Sequelize.HasManyRemoveAssociationMixin<comuna, comunaId>;
  removeComunas!: Sequelize.HasManyRemoveAssociationsMixin<comuna, comunaId>;
  hasComuna!: Sequelize.HasManyHasAssociationMixin<comuna, comunaId>;
  hasComunas!: Sequelize.HasManyHasAssociationsMixin<comuna, comunaId>;
  countComunas!: Sequelize.HasManyCountAssociationsMixin;

  static initModel(sequelize: Sequelize.Sequelize): typeof ciudad {
    return ciudad.init({
    id_ciudad: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    nombre_ciudad: {
      type: DataTypes.STRING(90),
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'ciudad',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_ciudad",
        unique: true,
        fields: [
          { name: "id_ciudad" },
        ]
      },
    ]
  });
  }
}
