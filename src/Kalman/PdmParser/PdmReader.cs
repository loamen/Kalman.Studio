using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Kalman.Utilities;
using System.IO;

namespace Kalman.PdmParser
{
    /// <summary>
    /// PDM文件读取类
    /// </summary>
    public class PdmReader
    {
        XmlDocument doc = new XmlDocument();
        string tempFileName = string.Empty;

        public PdmReader(string fileName)
        {
            try
            {
                doc.Load(fileName);
            }
            catch (IOException ex)
            {
                string dic = Path.GetDirectoryName(fileName);
                string tempFileName = Path.Combine(dic, Path.GetFileNameWithoutExtension(fileName) + ".tmp");
                File.Copy(fileName, tempFileName, true);
                doc.Load(tempFileName);
            }
        }

        /// <summary>
        /// 解析并生成模型实例
        /// </summary>
        /// <returns></returns>
        public PDModel BuildModel()
        {
            PDModel m = new PDModel();

            XmlElement docElement = doc.DocumentElement;
            XmlNode root = docElement.FirstChild.FirstChild.FirstChild;
            if (root == null) return null;

            m.ID = root.Attributes["Id"].Value;
            foreach (XmlNode node in root.ChildNodes)
            {
                switch (node.Name)
                {
                    case "a:Name":
                        m.Name = node.InnerText;
                        break;
                    case "a:Code":
                        m.Code = node.InnerText;
                        break;
                    case "a:Comment":
                        m.Comment = node.InnerText;
                        break;
                    case "c:DBMS":
                        ParseDbms(m, node);
                        break;
                    case "c:Packages":
                        ParsePackages(m, null, node);
                        break;
                    case "c:Users":
                        ParseUsers(m, node);
                        break;
                    case "c:Domains":
                        break;
                    case "c:Tables":
                        ParseTables(m, null, node);
                        break;
                    case "c:Views":
                        ParseViews(m, null, node);
                        break;
                    case "c:Procedures":
                        ParseProcedures(m, null, node);
                        break;
                    case "c:References":
                        ParseReferences(m, null, node);
                        break;
                    default:
                        m.AddUnparsedNode(node);
                        break;
                }
            }

            return m;
        }

        #region ParseDbms
        void ParseDbms(PDModel m, XmlNode root)
        {
            PDDbms dbms = new PDDbms();
            XmlNode shortcutNode = root.FirstChild;

            dbms.Model = m;
            dbms.ID = shortcutNode.Attributes["Id"].Value;

            foreach (XmlNode node in shortcutNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case "a:Name":
                        dbms.Name = node.InnerText;
                        break;
                    case "a:Code":
                        dbms.Code = node.InnerText;
                        break;
                    case "a:Comment":
                        dbms.Comment = node.InnerText;
                        break;
                    default:
                        dbms.AddUnparsedNode(node);
                        break;
                }
            }

            m.DBMS = dbms;
        }
        #endregion

        #region ParsePackages
        void ParsePackages(PDModel m,PDPackage parent, XmlNode root)
        {
            foreach (XmlNode packageNode in root.ChildNodes)
            {
                PDPackage package = new PDPackage();
                package.Model = m;
                package.Parent = parent;
                package.ID = packageNode.Attributes["Id"].Value;

                foreach (XmlNode node in packageNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            package.Name = node.InnerText;
                            break;
                        case "a:Code":
                            package.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            package.Comment = node.InnerText;
                            break;
                        case "c:Packages":
                            ParsePackages(m, package, node);
                            break;
                        case "c:Tables":
                            ParseTables(m, package, node);
                            break;
                        case "c:Views":
                            ParseViews(m, package, node);
                            break;
                        case "c:Procedures":
                            ParseProcedures(m, package, node);
                            break;
                        case "c:References":
                            ParseReferences(m, package, node);
                            break;
                        default:
                            package.AddUnparsedNode(node);
                            break;
                    }
                }//end parse package

                if (parent == null)
                {
                    m.AddPackage(package);
                }
                else
                {
                    parent.AddPackage(package);
                }
            }//end parse packages
        }
        #endregion

        #region ParseUsers
        void ParseUsers(PDModel m, XmlNode root)
        {
            foreach (XmlNode userNode in root.ChildNodes)
            {
                PDUser user = new PDUser();
                user.Model = m;
                user.ID = userNode.Attributes["Id"].Value;

                foreach (XmlNode node in userNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            user.Name = node.InnerText;
                            break;
                        case "a:Code":
                            user.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            user.Comment = node.InnerText;
                            break;
                        default:
                            user.AddUnparsedNode(node);
                            break;
                    }
                }//end parse user

                m.AddUser(user);
            }//end parse users
        }
        #endregion

        #region ParseTables
        void ParseTables(PDModel m, PDPackage package, XmlNode root)
        {
            foreach (XmlNode tableNode in root.ChildNodes)
            {
                PDTable table = new PDTable();
                table.Model = m;
                table.Package = package;
                table.ID = tableNode.Attributes["Id"].Value;

                foreach (XmlNode node in tableNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            table.Name = node.InnerText;
                            break;
                        case "a:Code":
                            table.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            table.Comment = node.InnerText;
                            break;
                        case "c:Owner":
                            table.UserID = node["o:User"].Attributes["Ref"].Value;
                            break;
                        case "c:PrimaryKey":
                            table.PrimaryKeyID = node["o:Key"].Attributes["Ref"].Value;
                            break;
                        case "c:ClusterObject":
                            table.ClusterObjectID = node.FirstChild.Attributes["Ref"].Value;
                            break;
                        case "c:Columns":
                            ParseColumns(m, package, table, node);
                            break;
                        case "c:Keys":
                            ParseKeys(m, package, table, node);
                            break;
                        case "c:Indexes":
                            ParseIndexes(m, package, table, node);
                            break;
                        default:
                            table.AddUnparsedNode(node);
                            break;
                    }
                }//end parse table

                if (package == null)
                {
                    m.AddTable(table);
                }
                else
                {
                    package.AddTable(table);
                }
            }//end parse tables
        }

        void ParseColumns(PDModel m, PDPackage package,PDTable table,XmlNode root)
        {
            foreach (XmlNode columnNode in root.ChildNodes)
            {
                PDColumn column = new PDColumn();
                column.Model = m;
                column.Package = package;
                column.Table = table;
                column.ID = columnNode.Attributes["Id"].Value;

                foreach (XmlNode node in columnNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            column.Name = node.InnerText;
                            break;
                        case "a:Code":
                            column.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            column.Comment = node.InnerText;
                            break;
                        case "a:DataType":
                            column.DataType = node.InnerText;
                            break;
                        case "a:Length":
                            column.Length = ConvertUtil.ToInt32(node.InnerText, 0);
                            break;
                        case "a:Precision":
                            column.Precision = ConvertUtil.ToInt32(node.InnerText, 0);
                            break;
                        case "a:Mandatory":
                            column.Mandatory = node.InnerText == "1" ? true : false;
                            break;
                        case "a:DefaultValue":
                            column.DefaultValue = node.InnerText;
                            break;
                        case "a:Identity":
                            column.Identity = node.InnerText == "1";
                            break;
                        default:
                            column.AddUnparsedNode(node);
                            break;
                    }
                }//end parse column

                table.AddColumn(column);
            }//end parse columns
        }

        void ParseKeys(PDModel m, PDPackage package, PDTable table, XmlNode root)
        {
            foreach (XmlNode keyNode in root.ChildNodes)
            {
                PDKey key = new PDKey();
                key.Model = m;
                key.Package = package;
                key.Table = table;
                key.ID = keyNode.Attributes["Id"].Value;

                foreach (XmlNode node in keyNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            key.Name = node.InnerText;
                            break;
                        case "a:Code":
                            key.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            key.Comment = node.InnerText;
                            break;
                        case "c:Key.Columns":
                            key.ColumnIDList = ParseKeyColumnIDs(node.ChildNodes);
                            break;
                        default:
                            break;
                    }
                }//end parse key

                table.AddKey(key);
            }//end parse keys
        }
        //解析键所包含列的ID列表
        IList<string> ParseKeyColumnIDs(XmlNodeList nodeList)
        {
            IList<string> list = new List<string>();
            foreach (XmlNode node in nodeList)
            {
                string id = node.Attributes["Ref"].Value;
                list.Add(id);
            }
            return list;
        }

        void ParseIndexes(PDModel m, PDPackage package, PDTable table, XmlNode root)
        {
            foreach (XmlNode indexNode in root.ChildNodes)
            {
                PDIndex index = new PDIndex();
                index.Model = m;
                index.Package = package;
                index.Table = table;
                index.ID = indexNode.Attributes["Id"].Value;

                foreach (XmlNode node in indexNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            index.Name = node.InnerText;
                            break;
                        case "a:Code":
                            index.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            index.Comment = node.InnerText;
                            break;
                        case "a:Unique":
                            index.Unique = node.InnerText == "1" ? true : false;
                            break;
                        case "c:IndexColumns":
                            index.ColumnIDList = ParseIndexColumnIDs(node.ChildNodes);
                            break;
                        default:
                            break;
                    }
                }//end parse index

                table.AddIndex(index);
            }//end parse indexes
        }
        //解析索引所包含列的ID列表
        IList<string> ParseIndexColumnIDs(XmlNodeList nodeList)
        {
            IList<string> list = new List<string>();
            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode n1 in node.ChildNodes)
                {
                    if (n1.Name == "c:Column")
                    {
                        list.Add(n1.FirstChild.Attributes["Ref"].Value);
                    }
                }
            }
            return list;
        }
        #endregion

        #region ParseViews
        void ParseViews(PDModel m, PDPackage package, XmlNode root)
        {
            foreach (XmlNode viewNode in root.ChildNodes)
            {
                PDView view = new PDView();
                view.Model = m;
                view.Package = package;
                view.ID = viewNode.Attributes["Id"].Value;

                foreach (XmlNode node in viewNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            view.Name = node.InnerText;
                            break;
                        case "a:Code":
                            view.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            view.Comment = node.InnerText;
                            break;
                        default:
                            break;
                    }
                }//end parse view

                if (package == null)
                {
                    m.AddView(view);
                }
                else
                {
                    package.AddView(view);
                }
            }//end parse views
        }
        #endregion

        #region ParseProcedures
        void ParseProcedures(PDModel m, PDPackage package, XmlNode root)
        {
            foreach (XmlNode procedureNode in root.ChildNodes)
            {
                PDProcedure procedure = new PDProcedure();
                procedure.Model = m;
                procedure.Package = package;
                procedure.ID = procedureNode.Attributes["Id"].Value;

                foreach (XmlNode node in procedureNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            procedure.Name = node.InnerText;
                            break;
                        case "a:Code":
                            procedure.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            procedure.Comment = node.InnerText;
                            break;
                        default:
                            break;
                    }
                }//end parse procedure

                if (package == null)
                {
                    m.AddProcedure(procedure);
                }
                else
                {
                    package.AddProcedure(procedure);
                }
            }//end parse procedures
        }
        #endregion

        #region ParseReferences
        void ParseReferences(PDModel m, PDPackage package, XmlNode root)
        {
            foreach (XmlNode referenceNode in root.ChildNodes)
            {
                PDReference reference = new PDReference();
                reference.Model = m;
                reference.Package = package;
                reference.ID = referenceNode.Attributes["Id"].Value;

                foreach (XmlNode node in referenceNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "a:Name":
                            reference.Name = node.InnerText;
                            break;
                        case "a:Code":
                            reference.Code = node.InnerText;
                            break;
                        case "a:Comment":
                            reference.Comment = node.InnerText;
                            break;
                        case "a:Cardinality":
                            reference.Cardinality = node.InnerText;
                            break;
                        case "a:UpdateConstraint":
                            reference.UpdateConstraint = node.InnerText == "1" ? true : false;
                            break;
                        case "a:DeleteConstraint":
                            reference.DeleteConstraint = node.InnerText == "1" ? true : false;
                            break;
                        case "c:ParentTable":
                            reference.ParentTableID = node.FirstChild.Attributes["Ref"].Value;
                            break;
                        case "c:ChildTable":
                            reference.ChildTableID = node.FirstChild.Attributes["Ref"].Value;
                            break;
                        case "c:ParentKey":
                            reference.ParentKeyID = node.FirstChild.Attributes["Ref"].Value;
                            break;
                        case "c:Joins":
                            reference.JoinList = ParseJoins(node.ChildNodes);
                            break;
                        default:
                            break;
                    }
                }//end parse reference

                if (package == null)
                {
                    m.AddReference(reference);
                }
                else
                {
                    package.AddReference(reference);
                }
            }//end parse references
        }

        IList<ReferenceJoin> ParseJoins(XmlNodeList nodeList)
        {
            IList<ReferenceJoin> list = new List<ReferenceJoin>();

            foreach (XmlNode node in nodeList)
            {
                ReferenceJoin join = new ReferenceJoin();
                join.ID = node.Attributes["Id"].Value;

                foreach (XmlNode n1 in node.ChildNodes)
                {
                    if (n1.Name == "c:Object1")
                    {
                        join.ParentColumnID = n1.FirstChild.Attributes["Ref"].Value;
                    }
                    if (n1.Name == "c:Object2")
                    {
                        join.ChildColumnID = n1.FirstChild.Attributes["Ref"].Value;
                    }
                }

                list.Add(join);
            }

            return list;
        }
        #endregion
    }
}
