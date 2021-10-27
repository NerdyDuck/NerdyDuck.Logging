#region Copyright
/*******************************************************************************
 * NerdyDuck.Logging - Base classes for customized logging for .NET.
 * 
 * The MIT License (MIT)
 *
 * Copyright (c) Daniel Kopp, dak@nerdyduck.de
 *
 * All rights reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 ******************************************************************************/
#endregion

global using System;

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NerdyDuck.CodedExceptions;

// General information
[assembly: CLSCompliant(true)]
[assembly: ComVisible(true)]
[assembly: AssemblyTrademark("Covered by MIT License")]
[assembly: InternalsVisibleTo("NerdyDuck.Tests.Logging, PublicKey=00240000048000009400000006020000002400005253413100040000010001003969c06980f24d9f79485faa59f967acf6252bf9e139c57b861ebffbce1c43349939c2fc05fdafe285bdc8ffc143385959125c88d01d920e937bfe4a0d8efe45171cb5311087a39cb73ef1ef3aeb0e018fac2cc05d39dd650a6cb0500cbcbe1d70a11f2fb472947146d2a51b8b8c5c5aabdc6b14dd267283f29ebc086f7901c2")]
[assembly: InternalsVisibleTo("NerdyDuck.Tests.Logging.Configuration, PublicKey=00240000048000009400000006020000002400005253413100040000010001003969c06980f24d9f79485faa59f967acf6252bf9e139c57b861ebffbce1c43349939c2fc05fdafe285bdc8ffc143385959125c88d01d920e937bfe4a0d8efe45171cb5311087a39cb73ef1ef3aeb0e018fac2cc05d39dd650a6cb0500cbcbe1d70a11f2fb472947146d2a51b8b8c5c5aabdc6b14dd267283f29ebc086f7901c2")]
[assembly: AssemblyFacilityIdentifier(0x0005)]
