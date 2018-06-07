using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Kalman.PdmParser
{
    /// <summary>
    /// PowerDesinger物理模型对象基类
    /// </summary>
    [Serializable]
    public class PDObject
    {
        /// <summary>
        /// 所属模型对象
        /// </summary>
        public PDModel Model { get; set; }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }

        //未解析节点列表
        [NonSerialized]
        Dictionary<string, XmlNode> _UnparsedNodeList = new Dictionary<string, XmlNode>();

        /// <summary>
        /// 添加未解析节点
        /// </summary>
        /// <param name="node"></param>
        public void AddUnparsedNode(XmlNode node)
        {
            _UnparsedNodeList.Add(node.Name, node);
        }
       
        /// <summary>
        /// 获取未解析节点
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public XmlNode GetUnparsedNode(string nodeName)
        {
            return _UnparsedNodeList[nodeName];
        }

        /// <summary>
        /// 获取未解析节点列表
        /// </summary>
        /// <returns></returns>
        public IList<XmlNode> GetUnparsedNodeList()
        {
            IList<XmlNode> list = new List<XmlNode>();
            foreach (KeyValuePair<string,XmlNode> item in _UnparsedNodeList)
            {
                list.Add(item.Value);
            }
            return list;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
