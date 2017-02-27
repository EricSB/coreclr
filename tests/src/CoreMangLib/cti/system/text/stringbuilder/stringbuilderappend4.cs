// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Text;
/// <summary>
/// StringBuilder.Append(Char[])
/// </summary>
public class StringBuilderAppend4
{
    public static int Main()
    {
        StringBuilderAppend4 sbAppend4 = new StringBuilderAppend4();
        TestLibrary.TestFramework.BeginTestCase("StringBuilderAppend4");
        if (sbAppend4.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        retVal = PosTest4() && retVal;
        return retVal;
    }
    #region PositiveTest
    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1:Invoke Append method in the initial StringBuilder 1");
        try
        {
            StringBuilder sb = new StringBuilder();
            char charValue1 = TestLibrary.Generator.GetChar(-55);
            char charValue2 = TestLibrary.Generator.GetChar(-55);
            char charValue3 = TestLibrary.Generator.GetChar(-55);
            char[] charBuffer = new char[] { charValue1, charValue2, charValue3 };
            sb = sb.Append(charBuffer);
            if (sb.ToString() != new string(charBuffer))
            {
                TestLibrary.TestFramework.LogError("001", "The ExpectResult is not the ActualResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpect exception:" + e);
            retVal = false;
        }
        return retVal;
    }
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2:Invoke Append method in the initial StringBuilder 2");
        try
        {
            string strSource = "formytest";
            StringBuilder sb = new StringBuilder(strSource);
            char charValue1 = TestLibrary.Generator.GetChar(-55);
            char charValue2 = TestLibrary.Generator.GetChar(-55);
            char charValue3 = TestLibrary.Generator.GetChar(-55);
            char[] charBuffer = new char[] { charValue1, charValue2, charValue3 };
            sb = sb.Append(charBuffer);
            if (sb.ToString() != strSource + new string(charBuffer))
            {
                TestLibrary.TestFramework.LogError("003", "The ExpectResult is not the ActualResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpect exception:" + e);
            retVal = false;
        }
        return retVal;
    }
    public bool PosTest3()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest3:Invoke Append method in the initial StringBuilder 3");
        try
        {
            string strSource = null;
            StringBuilder sb = new StringBuilder(strSource);
            char charValue1 = TestLibrary.Generator.GetChar(-55);
            char charValue2 = TestLibrary.Generator.GetChar(-55);
            char charValue3 = TestLibrary.Generator.GetChar(-55);
            char[] charBuffer = new char[] { charValue1, charValue2, charValue3 };
            sb = sb.Append(charBuffer);
            if (sb.ToString() != new string(charBuffer))
            {
                TestLibrary.TestFramework.LogError("005", "The ExpectResult is not the ActualResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpect exception:" + e);
            retVal = false;
        }
        return retVal;
    }
    public bool PosTest4()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest4:Invoke Append method in the initial StringBuilder 4");
        try
        {
            string strSource = null;
            StringBuilder sb = new StringBuilder(strSource);
            char[] charBuffer = null;
            sb = sb.Append(charBuffer);
            if (sb.ToString() != string.Empty)
            {
                TestLibrary.TestFramework.LogError("007", "The ExpectResult is not the ActualResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("008", "Unexpect exception:" + e);
            retVal = false;
        }
        return retVal;
    }
    #endregion
}
