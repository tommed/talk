namespace Medhurst.CodeTalk.LiskovSubstitution
{
    public class SportsCar : Car
    {
        public override void DriveFast(Driver driver)
        {
            base.DriveFast(driver);

            // GOOD: ensure the state of this class is as you'd expect
            // it after applying sub-class logic
            // i.o.w. You have asserted your own logic
            Guard.Post.EnsureIsNowTrue(driver.TrousersAreTight);
        }
    }
}
