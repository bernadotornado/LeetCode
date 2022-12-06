using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Principal;
using System.Threading;
using System.Threading.Channels;
using LeetCode;

namespace _1106._Parsing_A_Boolean_Expression
{
    class Solution
    {
        const char _true = 't';
        const char _false = 'f';
        const char _not = '!';
        const char _and = '&';
        const char _or = '|';
        const char _parOpen = '(';
        const char _parClosed = ')';
        const char _comma = ',';
        
        private static void GetSubExpressionParentheses(string symbols, out int lastOpenPar, out int firstClosedPar)
        {
            lastOpenPar = 0;
            firstClosedPar = 0;
            for (int i = 0; i < symbols.Length; i++)
                if (symbols[i] == _parOpen && i > lastOpenPar)
                    lastOpenPar = i;
                
            for (int i = lastOpenPar; i < symbols.Length; i++)
                if (symbols[i] == _parClosed && (firstClosedPar == 0))
                    firstClosedPar = i;
        }
        private static string SubExpression(int lastOpenPar, int firstClosedPar, string symbols)
        {
            string subExpression = "";
            for (int i = lastOpenPar - 1; i <= firstClosedPar; i++)
                subExpression += symbols[i];

            return subExpression;
        }
        public static bool EvalBool(char s)
        {
            switch (s)
            {
                case _true: return true;
                case _false: return false;
                default: return false;
            }
        }
        public static string EvaluateSubExpression(string s)
        {
            string f = s.Substring(2, s.Length - 3);
            var bools = f.Split(_comma);
            bool res = EvalBool(bools[0][0]);
            
            for (int i = 1; i < bools.Length; i++)
                switch (s[0])
                {
                    case _and:
                        res = res && EvalBool(bools[i][0]);
                        break;
                    case _or: 
                        res = res || EvalBool(bools[i][0]);
                        break;
                }

            return ((s[0] == _not? !res: res)? _true:_false).ToString();
        }
        private static string GetNextIteration(string expression)
        {
            GetSubExpressionParentheses(expression, out int lastOpenPar, out int firstClosedPar);
            var subExpression = SubExpression(lastOpenPar, firstClosedPar, expression);
            var evalExpression = EvaluateSubExpression(subExpression);
            var next = expression.Substring(0, lastOpenPar - 1) + evalExpression + expression.Substring(firstClosedPar + 1);
            return next;
        }
        public static bool ParseBoolExpr(string expression)
        {
            var next = expression;
            var last = expression;
            while (next.Length > 1)
            {
                next = GetNextIteration(last);
                last = next;
            }
                
            return EvalBool(last[0]);
        }

       

      

       

        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), ParseBoolExpr,"|(&(t,f,t),!(&(t,t,f,f,!(|(f,f)))))");
        }
    }
}
