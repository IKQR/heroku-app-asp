using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerokuApplication.Dal.Entity
{
    [Table("neural_learn_mask")]
    public class NeuralLearnMask
    {
        [Key]
        [Column("id")]
        public Int32 Id { get; set; }
        [Column("settings")]
        public string Settings { get; set; }
        [Column("symbol")]
        public string Symbol { get; set; }
        [Column("learn_good_set_q")]
        public string LearnGoodSetQ { get; set; }
        [Column("learn_bad_set_q")]
        public string LearnBadSetQ { get; set; }
        [Column("kooef")]
        public string Koef { get; set; }
        [Column("good_accuracy_procent")]
        public string GoodAccuracyPercentage { get; set; }
        [Column("bad_accuracy_procent")]
        public string BadAccuracyPercentage { get; set; }
    }
}
