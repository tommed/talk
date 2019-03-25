using System;

namespace Medhurst.CodeTalk
{
    public static class Guard
    {
        public static class Pre
        {
            public static void MustBeTrue(bool condition, string reason = null)
            {
                if (!condition)
                {
                    throw new ArgumentException(reason ?? "condition should have been true");
                }
            }

            public static void MustBeEqual(object o1, object o2, string reason = null)
            {
                if (o1 != o2)
                {
                    throw new ArgumentException(reason ?? $"Objects {o1} and {o2} aren't equal");
                }
            }

            public static void MustBeGreaterThan(float f1, float f2, string reason = null)
            {
                if (f1 > f2)
                {
                    throw new ArgumentException(reason ?? $"Value {f1} should have been greater than {f2}");
                }
            }
        }

        public static class Post
        {
            public static void EnsureIsNowTrue(bool condition, string reason = null)
            {
                if (!condition)
                {
                    throw new ArgumentException(reason ?? "Condition should have been true, but wasn't");
                }
            }
        }
    }
}
