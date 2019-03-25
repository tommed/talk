namespace Medhurst.CodeTalk.LiskovSubstitution
{
    public enum DriverLocation
    {
        AwayFromCar,
        InBoot,
        Asleep,
        InDriverSeat
    }

    public sealed class Driver
    {
        public DriverLocation Location { get; }

        public bool TrousersAreTight { get; set; }
    }

    public enum CarNoises
    {
        SexyNoiseMakesTrousersTight
    }

    public abstract class Car
    {
        public virtual bool HasEngine { get; }

        public virtual float EngineCapacityLtrs { get; }

        public virtual CarNoises EngineNoise { get; }

        public virtual void DriveFast(Driver driver)
        {
            Guard.Pre.MustBeTrue(this.HasEngine);
            Guard.Pre.MustBeEqual(driver.Location, DriverLocation.InDriverSeat);

            // ... logic for driving the car
        }
    }
}
