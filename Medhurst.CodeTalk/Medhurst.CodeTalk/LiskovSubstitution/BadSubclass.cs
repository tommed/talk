namespace Medhurst.CodeTalk.LiskovSubstitution
{
    public class SuperCar : Car
    {
        public override void DriveFast(Driver driver)
        {
            // BAD: additional pre-guarding breaks Liskov
            // as it raises the bar to entry
            Guard.Pre.MustBeGreaterThan(this.EngineCapacityLtrs, 2.5F);
            Guard.Pre.MustBeEqual(
                this.EngineNoise,
                CarNoises.SexyNoiseMakesTrousersTight);

            base.DriveFast(driver);
        }
    }
}
