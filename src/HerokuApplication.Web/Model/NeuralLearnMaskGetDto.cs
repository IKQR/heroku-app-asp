using System;
using System.Text.Json.Serialization;

namespace HerokuApplication.Web.Model
{
    public class NeuralLearnMaskGetDto
    {
        [JsonPropertyName("id")]
        public Int32 Id { get; set; }
        //[JsonPropertyName("settings")]
        //public string Settings { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        //[JsonPropertyName("learn_good_set_q")]
        //public string LearnGoodSetQ { get; set; }
        //[JsonPropertyName("learn_bad_set_q")]
        //public string LearnBadSetQ { get; set; }
        //[JsonPropertyName("kooef")]
        //public double Koef { get; set; }
        [JsonPropertyName("good_accuracy_procent")]
        public double GoodAccuracyPercentage { get; set; }
        [JsonPropertyName("bad_accuracy_procent")]
        public double BadAccuracyPercentage { get; set; }
    }
}
