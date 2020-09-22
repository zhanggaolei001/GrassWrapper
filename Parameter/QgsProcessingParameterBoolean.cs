namespace GrassWrapper.Parameter
{
    /// <summary>
    ///  QgsProcessingParameterBoolean:171
    /// </summary>
    public class QgsProcessingParameterBoolean : ParameterBase<bool>
    {
        //QgsProcessingParameterBoolean( const QString &name, const QString &description = QString(), const QVariant &defaultValue = QVariant(),bool optional = false );
        public QgsProcessingParameterBoolean(string[] arr) : base(arr)
        {

            if (arr.Length > 3 && arr[3] != "None" && !string.IsNullOrEmpty(arr[3]))
            {
                DefaultValue = bool.Parse(arr[3].ToLower());
                Value = DefaultValue;
            }
            if (arr.Length > 4)
            {
                Optional = bool.Parse(arr[4].ToLower());
            }
        }

        public override string ToString()
        {
            if (Value)
            {
                return Name;
            }
            else
            {
                return "";
            }
        }
    }
}