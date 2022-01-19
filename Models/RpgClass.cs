using System;
using System.Text.Json.Serialization;

namespace models.first_web_api
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // thats use to see the content of array in browser :) 
    public enum RpgClass
    {
            Bader , 
            Nader , 
            Rami 
    }



}