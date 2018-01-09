using Korzunina.Logic;
using System.Collections.Generic;

namespace Korzunina.Visualization
{
    static class TestData
    {
        public static readonly Matrix RealMapDots = new Matrix(new double[,] { { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 },
                                                                               { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
                                                                               { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 },
                                                                               { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }});

        public static readonly Dictionary<int, List<int>> AdjacentPointsDic = new Dictionary<int, List<int>>()
                                                                               { { 0, new List<int> { 6, 3, 1    } },
                                                                                 { 1, new List<int> { 4, 7, 2    } },
                                                                                 { 2, new List<int> { 5, 8       } },
                                                                                 { 3, new List<int> { 4, 9       } },
                                                                                 { 4, new List<int> { 10, 5      } },
                                                                                 { 5, new List<int> { 11         } },
                                                                                 { 6, new List<int> { 12, 9, 7   } },
                                                                                 { 7, new List<int> { 10, 13, 8  } },
                                                                                 { 8, new List<int> { 11, 14     } },
                                                                                 { 9, new List<int> { 6, 10, 15  } },
                                                                                 { 10, new List<int> { 7, 11, 16 } },
                                                                                 { 11, new List<int> { 17        } },
                                                                                 { 13, new List<int> { 16        } },
                                                                                 { 14, new List<int> { 17        } },
                                                                                 { 15, new List<int> { 12, 16    } },
                                                                                 { 16, new List<int> { 17, 13    } }};

    }
}
