using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge.Services
{
    class MockedRuleService : IRuleRepository
    {
        private Rule rule1;
        private Rule rule2;


        public MockedRuleService()
        {
            rule1 = createRule();
            rule2 = createRule();
        }

        private Rule createRule()
        {
            Random rnd = new Random();

            Rule rule = new Rule();
            int[] integers = { rnd.Next(), rnd.Next(), rnd.Next(), rnd.Next() };
            rule.CheckPositionIds = integers;
            rule.Id = rnd.Next();
            rule.IsDynamicRule = false;
            rule.MaxVelocity = rnd.Next();
            rule.PositionId = rnd.Next();
            rule.X = rnd.Next();
            rule.Y = rnd.Next();
            return rule;
        }

        public Rule Create(Rule rule)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rule rule)
        {
            return;
        }

        public IEnumerable<Rule> GetAllRules()
        {
            List<Rule> rules = new List<Rule>();

            rules.Add(rule1);
            rules.Add(rule2);

            for (int i = 0; i < 10; i++)
            {
                rules.Add(createRule());
            }
            return rules;
        }

        public IEnumerable<Rule> GetDynamicRules()
        {
            List<Rule> rules = new List<Rule>();

            rules.Add(rule1);
            rules.Add(rule2);

            for (int i = 0; i < 10; i++)
            {
                rules.Add(createRule());
            }
            return rules;
        }

        public Rule GetRule(int ruleId)
        {
            Rule rule = createRule();
            rule.Id = ruleId;
            return rule;
        }

        public IEnumerable<Rule> GetStaticRules()
        {
            List<Rule> rules = new List<Rule>();

            rules.Add(rule1);
            rules.Add(rule2);

            for (int i = 0; i < 10; i++)
            {
                rules.Add(createRule());
            }
            return rules;
        }

        public Rule Update(Rule rule)
        {
            return rule;
        }
    }
}
