using ArreMath;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderML
{
    public class Class1
    {
        public Class1()
        {
            var mlContext = new MLContext();
            List<TrainFace> trainFaceData = MongoDBApi.MongoDBClient.Current.GetAllDataNormalisedFromTable("glasses");
            var dataView = mlContext.Data.LoadFromEnumerable(trainFaceData);

            var features = dataView.Schema.Select(col => col.Name).Where(colName => colName != "HairColor" && colName != "Label").ToArray();

            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "HairColor", inputColumnName: nameof(TrainFace.HairColor))
                .Append(mlContext.Transforms.Concatenate("Features", features));

            var preppedData = dataProcessPipeline.Fit(dataView);
            var trainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");
            var pipeline = dataProcessPipeline.Append(trainer);
            var model = pipeline.Fit(dataView);

            var predictions = model.Transform(dataView);
            var predictionFunc = mlContext.Model.CreatePredictionEngine<TrainFace, SwipePrediction>(model);

            var trainFace = new TrainFace(ArresFace.GetArresFace());

            var swipePrediction = predictionFunc.Predict(trainFace);
            Console.WriteLine("SwipeDirection");
            Console.WriteLine(swipePrediction.SwipeRight);

        }
    }
}
