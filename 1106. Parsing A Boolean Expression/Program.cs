﻿using System;
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

        static void AddChildrenToOperator(char _operator)
        {

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
            if (s[0] == _not)
                return EvalBool(res? _false:_true).ToString();
            
            for (int i = 1; i < bools.Length; i++)
            {
                switch (s[0])
                {
                    case _and:
                        res = res && EvalBool(bools[i][0]);
                        break;
                    case _or: 
                        res = res || EvalBool(bools[i][0]);
                        break;
                }
            }

            return (res? _true:_false).ToString();
        }
        public static bool ParseBoolExpr(string expression)
        {
            var next = expression;
            var last = expression;
            while (next.Length > 1)
            {
                Console.WriteLine($"last: {last}, next: {next}");
                next = GetNextIteration(last);
                last = next;
                // var nexter = GetNextIteration(next);
                // Console.WriteLine("nexter: "+ nexter); 
            }
            Console.WriteLine($"last: {last}, next: {next}");
            
            // if (expression.Length > 1)
            // {
            //         
            // }
            //
            //
            // else 
                return EvalBool(last[0]);

            return false;
        }

        private static string GetNextIteration(string expression)
        {
            var symbols = expression.ToCharArray();
            var lastOpenPar = 0;
            var firstClosedPar = 0;
            string subExpression = "";
            string evalExpression = "";
            string next = "";
            
                GetSubExpressionParentheses(symbols, ref lastOpenPar, ref firstClosedPar);
                subExpression = SubExpression(lastOpenPar, firstClosedPar, symbols);
                evalExpression = EvaluateSubExpression(subExpression);
                //Console.WriteLine("SubExpressionValue: " + evalExpression);
                next = expression.Substring(0, lastOpenPar - 1) + evalExpression + expression.Substring(firstClosedPar + 1);
                //Console.WriteLine("Next expr: " + next);
            
            
            return next;
        }

        private static void GetSubExpressionParentheses(char[] symbols, ref int lastOpenPar, ref int firstClosedPar)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == _parOpen && i > lastOpenPar)
                    lastOpenPar = i;
                if (symbols[i] == _parClosed && firstClosedPar == 0)
                    firstClosedPar = i;
            }
        }

        private static string SubExpression(int lastOpenPar, int firstClosedPar, char[] symbols)
        {
            string subExpression = "";
            for (int i = lastOpenPar - 1; i <= firstClosedPar; i++)
            {
                try
                {
                    subExpression += symbols[i];
                }
                catch 
                {
                
                }
            }

            return subExpression;
        }

        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), ParseBoolExpr,"!(&(f,t))");
        }
    }
}
