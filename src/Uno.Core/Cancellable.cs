// ******************************************************************
// Copyright � 2015-2018 nventive inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************
using System;
using System.Threading;
using Uno.Extensions;

namespace Uno
{
	public class Cancellable
	{
		private readonly Action _onCancel;
		private int _isCancelled = 0;

		public Cancellable(Action onCancel)
		{
			_onCancel = onCancel.Validation().NotNull("onCancel");
		}

		public bool IsCancelled { get { return _isCancelled != 0; } }

		public void Cancel()
		{
			if(Interlocked.Exchange(ref _isCancelled, 1) == 0)
			{
				_onCancel();
			}
		}
	}
}
