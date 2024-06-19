using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace pr6._22
{
    public partial class Form1 : Form
    {
        private CarStrategy carStrategy;
        interface IEngineStrategy
        {
            void Start();
            void Stop();
        }
        interface IFuelSystemStrategy
        {
            void SupplyFuel();
            void CutOffFuel();
        }
        interface ILightsStrategy
        {
            void TurnOn();
            void TurnOff();
        }
        interface ICarDiagnosticStrategy
        {
            void RunDiagnostic();
        }
        class EngineStrategy : IEngineStrategy
        {
            public void Start() { MessageBox.Show("Попытка запустить двигатель!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            public void Stop() { MessageBox.Show("Двигатель заглушен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        class FuelSystemStrategy : IFuelSystemStrategy
        {
            public void SupplyFuel() { MessageBox.Show("Подача топлива!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            public void CutOffFuel() { MessageBox.Show("Прекращение подачи топлива!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        class LightsStrategy : ILightsStrategy
        {
            public void TurnOn() { MessageBox.Show("Попытка включить фары!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            public void TurnOff() { }
        }
        class CarDiagnosticStrategy : ICarDiagnosticStrategy
        {
            public void RunDiagnostic() { }
        }
        class CarStrategy
        {
            private IEngineStrategy engineStrategy;
            private IFuelSystemStrategy fuelSystemStrategy;
            private ILightsStrategy lightsStrategy;
            private ICarDiagnosticStrategy carDiagnosticStrategy;
            public CarStrategy(IEngineStrategy engineStrategy, IFuelSystemStrategy fuelSystemStrategy, ILightsStrategy lightsStrategy, ICarDiagnosticStrategy carDiagnosticStrategy)
            {
                this.engineStrategy = engineStrategy;
                this.fuelSystemStrategy = fuelSystemStrategy;
                this.lightsStrategy = lightsStrategy;
                this.carDiagnosticStrategy = carDiagnosticStrategy;
            }
            public void StartEngine() => engineStrategy.Start(); // упрощенная запись анонимных методов, слева определяется список параметров, справа - использование этих параметров
            public void StopEngine() => engineStrategy.Stop();
            public void SupplyFuel() => fuelSystemStrategy.SupplyFuel();
            public void CutOffFuel() => fuelSystemStrategy.CutOffFuel();
            public void TurnOnLights() => lightsStrategy.TurnOn();
            public void TurnOffLights() => lightsStrategy.TurnOff();
            public void RunDiagnostics() => carDiagnosticStrategy.RunDiagnostic();
        }
        public Form1()
        {
            InitializeComponent();
            carStrategy = new CarStrategy(new EngineStrategy(), new FuelSystemStrategy(), new LightsStrategy(), new CarDiagnosticStrategy());
        }
        class RandomHelper
        {
            private static Random rnd = new Random();
            public static int GetRandomInt(int maxValue)
            {
                return rnd.Next(maxValue);
            }
        }
        private void btnStartEngine_Click(object sender, EventArgs e)
        {
            carStrategy.StartEngine();
            int random = RandomHelper.GetRandomInt(5);
            if (random == 0)
            {
                MessageBox.Show("Машина не запускается!", "Стартер сломался", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            { System.Diagnostics.Process.Start(@"D:\Users\1213-11\Documents\2-ИСП\Проектирование и дизайн информационных систем\Ghbptynfirf\запуск.gif"); }
        }
        private void btnStopEngine_Click(object sender, EventArgs e)
        {
            carStrategy.StopEngine();
        }
        private void btnSupplyFuel_Click(object sender, EventArgs e)
        {
            int random = RandomHelper.GetRandomInt(5);
            if (random == 0)
            {
                MessageBox.Show("Машина не заводится!", "Топливный насос сломался", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else { System.Diagnostics.Process.Start(@"D:\Users\1213-11\Documents\2-ИСП\Проектирование и дизайн информационных систем\Ghbptynfirf\enginestart.gif"); }
        }
        private void btnCutOffFuel_Click(object sender, EventArgs e)
        {
            carStrategy.CutOffFuel();
        }
        private void btntTurnOnLights_Click(object sender, EventArgs e)
        {
            carStrategy.TurnOnLights();
            int random = RandomHelper.GetRandomInt(5);
            if (random == 0)
            {
                MessageBox.Show("Фары не включаются!", "Аккумулятор разрядлся", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else { System.Diagnostics.Process.Start(@"D:\Users\1213-11\Documents\2-ИСП\Проектирование и дизайн информационных систем\Ghbptynfirf\c63.gif"); }
        }
        private void btnRunDiagnostics_Click(object sender, EventArgs e)
        {
            carStrategy.RunDiagnostics();
            System.Diagnostics.Process.Start(@"D:\Users\1213-11\Documents\2-ИСП\Проектирование и дизайн информационных систем\Ghbptynfirf\priborka.gif");
        }
        private void btnTurnOffLights_Click(object sender, EventArgs e)
        {
            carStrategy.TurnOffLights();
            System.Diagnostics.Process.Start(@"D:\Users\1213-11\Documents\2-ИСП\Проектирование и дизайн информационных систем\Ghbptynfirf\off.jpg");
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            выходToolStripMenuItem_Click(sender, e);
        }
    }
}