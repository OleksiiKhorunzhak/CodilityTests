using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiTests
{
	class Class1
	{
		public bool solution(int[] A, int K)
		{
			int n = A.Length;
			for (int i = 0; i < n - 1; i++)
			{
				if (A[i] + 1 < A[i + 1])
					return false;
			}
			if (A[0] != 1 && A[n - 1] != K && K > 0)
				return false;
			else
				return true;
		}
	}
}
