namespace Butterfly.system.objects.main.information
{
    public class DOM
    {
        /// <summary>
        /// Имя ключа по данный обьект был создан в родителe.
        /// </summary>
        public readonly string KeyObject;

        /// <summary>
        /// Уникальный номер ID для обьекта. 
        /// </summary>
        public readonly ulong ID;

        /// <summary>
        /// Уникальный ключ для всего узла. 
        /// </summary>
        public readonly ulong NodeID;

        /// <summary>
        /// Номер вложености узла в нутри всей системы.
        /// </summary>
        public readonly ulong NestingNodeNamberInTheSystem;

        /// <summary>
        /// Номер вложености обьекта в нутри узла. 
        /// Node обьект по умолчанию имеет номер 0.
        /// Данное поле имеет практический смысл для веток узла.
        /// </summary>
        public readonly ulong NestingObjectNamberInTheNode;

        /// <summary>
        /// Хранит массив родительских ID обьектов.
        /// Ветки определененые в нутри родительского узла тоже считаются родителями. 
        /// </summary>
        public readonly ulong[] ParentObjectsID;

        /// <summary>
        /// Ссылка на текущий обьект. 
        /// </summary>
        public readonly main.Object CurrentObject;

        /// <summary>
        /// Ссылка на родительский обьект. 
        /// </summary>
        public readonly main.Object ParentObject;

        /// <summary>
        /// Ссылка на Node объект. 
        /// </summary>
        public readonly main.Object NodeObject;

        /// <summary>
        /// Ссылка на ближайший узел определеный как Independent. 
        /// </summary>
        public readonly main.Object NearIndependentNodeObject;

        /// <summary>
        /// Ссылка на корневой узел.
        /// </summary>
        public readonly root.IManager RootManager;

        /// <summary>
        /// Инициализируем все необходимые данные DOM для ветки. 
        /// </summary>
        /// <param name="keyObject">Ключ обьекта по которому он был создан в родители.</param>
        /// <param name="nodeID">Уникальный ID узла в котором находится ветка.</param>
        /// <param name="nestingNodeNamberInTheSystem">Номер вложености текущего обьекта в системе.</param>
        /// <param name="nestingNodeNamberInTheNode">Номер вложености ветки в нутри узла.</param>
        /// <param name="parentObjectsID">Массив ID всех родителей.</param>
        /// <param name="currentObject">Ссылка на текущий обьект.</param>
        /// <param name="parentObject">Ссылка на родительский обьект.</param>
        /// <param name="nodeObject">Ссылка на обьект Node.</param>
        /// <param name="nearIndependentNodeObject">Ссылка на ближайший индивидуальный обьект.</param>
        /// <param name="rootManager">Ссылка на необходимые методы root обьекта.</param>
        public DOM(string keyObject, ulong nodeID, ulong nestingNodeNamberInTheSystem,
            ulong nestingNodeNamberInTheNode, ulong[] parentObjectsID, main.Object currentObject, 
                main.Object parentObject, main.Object nodeObject, main.Object nearIndependentNodeObject, root.IManager rootManager)
        {
            ID = s_indexUniqueObjectID++;

            KeyObject = keyObject;
            NodeID = nodeID;
            NestingNodeNamberInTheSystem = nestingNodeNamberInTheSystem;
            NestingObjectNamberInTheNode = nestingNodeNamberInTheNode;
            ParentObjectsID = Hellper.ExpendArray(parentObjectsID, ID);
            NodeObject = nodeObject;
            CurrentObject = currentObject;
            ParentObject = parentObject;
            NearIndependentNodeObject = nearIndependentNodeObject;
            RootManager = rootManager;
        }

        /// <summary>
        /// Инициализируем все необходимые данные DOM для узла.
        /// </summary>
        /// <param name="keyObject">Ключ обьекта по которому он был создан в родители.</param>
        /// <param name="nestingNodeNamberInTheSystem">Номер вложености текущего обьекта в системе.</param>
        /// <param name="parentObjectsID">Массив ID всех родителей.</param>
        /// <param name="currentObject">Ссылка на текущий обьект.</param>
        /// <param name="parentObject">Ссылка на родительский обьект.</param>
        /// <param name="nearIndependentNodeObject">Ссылка на ближайший индивидуальный обьект.</param>
        /// <param name="rootManager">Ссылка на необходимые методы root обьекта.</param>
        public DOM(string keyObject, ulong nestingNodeNamberInTheSystem, ulong[] parentObjectsID, 
                main.Object currentObject, main.Object parentObject, main.Object nearIndependentNodeObject,
                    root.IManager rootManager)
        {
            ID = s_indexUniqueObjectID++;
            NodeID = s_indexUniqueNodeID++;

            KeyObject = keyObject;
            NestingNodeNamberInTheSystem = nestingNodeNamberInTheSystem;
            ParentObjectsID = Hellper.ExpendArray(parentObjectsID, ID);
            CurrentObject = currentObject;
            NodeObject = currentObject;
            ParentObject = parentObject;
            NearIndependentNodeObject = nearIndependentNodeObject;
            RootManager = rootManager;
        }

        /// <summary>
        /// Хранит уникальный индекс ID для следующего обьекта. 
        /// </summary>
        private static ulong s_indexUniqueObjectID = 0;
        /// <summary>
        /// Хранит уникальный индекс ID для следующего узла. 
        /// </summary>
        private static ulong s_indexUniqueNodeID = 0;
    }
}