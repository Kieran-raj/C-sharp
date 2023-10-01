namespace Bridge
{
    public class Exercise
    {
        public interface IRenderer
        {
            string WhatToRenderAs { get; }
        }

        public abstract class Shape
        {
            private IRenderer _renderer;

            protected Shape(IRenderer renderer)
            {
                _renderer = renderer; 
            }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
            }
        }

        public class Triangle : Shape
        {
            public Triangle(IRenderer renderer) 
                : base(renderer)
            {
                Name = "Triangle";
            }
        }

        public class Square : Shape
        {
            public Square(IRenderer renderer)
                : base(renderer)
            {
                Name = "Square";
            }
        }

        public class RasterRenderer : IRenderer
        {
            public string WhatToRenderAs
            {
                get { return "pixels"; }
            }
        }

        public class VectorRenderer : IRenderer
        {
            public string WhatToRenderAs
            {
                get { return "lines"; }
            }
        }
    }
}
