using System;
using Core;
using System.Windows.Forms;
using UI.Repositories;
using UI.Classes;
using Core.Classes;
using Core.Interfaces;
using OptimizationMethods;
using System.Threading.Tasks;

namespace UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //var classesRepo = new AlgorithmClassesRepository();
            //var instancesRepo = new AlgorithmInstancesRepository(classesRepo);
            //var d1 = instancesRepo.All();
            //foreach (var item in classesRepo.All())
            //{
            //    instancesRepo.Create(item);
            //}
            //var d2 = instancesRepo.All();

            Guid svenId = Guid.NewGuid();
            // x1^2+x2^2-1.2*x1*x2
            (new InMemoryInitialParamsRepository(svenId)).Set(new SvenMethod.InitialParams()
            {
                f = (new MathFactory()).CreateScalarFunction("x1^2", new MathFactory()),
                h = (new MathFactory()).CreateScalar(0.2, new MathFactory()),
                x_0 = (new MathFactory()).CreateScalar(1, new MathFactory())
            });

            var sven = new SvenMethod
            (
                iterationsRepository: new InMemoryIterationsRepository(svenId),
                initialParamsRepository: new InMemoryInitialParamsRepository(svenId),
                mathFactory: new MathFactory()
            );

            var r = sven.GetTask().Result;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
