using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearning.HelloWorld
{
    public class HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public class Prediction
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }

    public class MachineLearningHelloWorld
    {

        public Prediction GetPredictedHousePriceBySize(float size)
        {
            MLContext context = new MLContext();

            // 1. Import or create training data
            HouseData[] houseData = {
               new HouseData() { Size = 1.1F, Price = 1.2F },
               new HouseData() { Size = 1.9F, Price = 2.3F },
               new HouseData() { Size = 2.8F, Price = 3.0F },
               new HouseData() { Size = 3.4F, Price = 3.7F } };

            IDataView traningData = context.Data.LoadFromEnumerable(houseData);

            var pipeline = context.Transforms.Concatenate("Features", new[] { "Size" })
                .Append(context.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

            var model = pipeline.Fit(traningData);

            var housesize = new HouseData() { Size = size };
            var predict = context.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(housesize);

            return predict;
        }
        
    }
}
