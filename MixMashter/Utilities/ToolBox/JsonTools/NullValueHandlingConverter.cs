using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MixMashter.Utilities.ToolBox.JsonTools
{


    public class NullValueHandlingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // Ce convertisseur peut être appliqué à tous les types d'objet
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // La lecture de la valeur JSON est gérée par le serializer par défaut
            return serializer.Deserialize(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Vérifie si la valeur est null
            if (value == null)
            {
                // Écrit une chaîne "null" dans le flux JSON
                writer.WriteValue("null");
            }
            else
            {
                // Sinon, laisse le serializer par défaut gérer l'écriture de la valeur
                serializer.Serialize(writer, value);
            }
        }
    }

}
