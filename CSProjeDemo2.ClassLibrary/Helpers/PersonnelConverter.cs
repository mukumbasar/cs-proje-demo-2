using CSProjeDemo2.ClassLibrary.Entities.Abstracts;
using CSProjeDemo2.ClassLibrary.Entities.Concretes;
using CSProjeDemo2.ClassLibrary.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace CSProjeDemo2.ClassLibrary.Helpers
{
    public class PersonnelConverter : JsonConverter<Personnel>
    {
        public override Personnel ReadJson(JsonReader reader, Type objectType, Personnel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Title title = jo["Title"].ToObject<Title>();

            Personnel personnel = null;

            switch (title)
            {
                case Title.CivilServant:
                    personnel = new CivilServant();
                    break;
                case Title.Manager:
                    personnel = new Manager();
                    break;
                default:
                    throw new ArgumentException("Unknown title");
            }

            serializer.Populate(jo.CreateReader(), personnel);

            return personnel;
        }


        public override void WriteJson(JsonWriter writer, Personnel value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
