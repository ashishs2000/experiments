using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class LanguageParser
    {
        public void Run()
        {
            var commands = new List<BaseCommand>();
            commands.Add(new BaseCommand("if"));
            commands.Add(new BaseCommand("select1"));
            commands.Add(new BaseCommand("elseif"));
            commands.Add(new BaseCommand("select2"));
            commands.Add(new BaseCommand("if"));
            commands.Add(new BaseCommand("select3"));
            commands.Add(new BaseCommand("endif"));
            commands.Add(new BaseCommand("endif"));

            var blocks = new Stack<BaseTestBlock>();
            var blockAndCommands = new List<object>();
            foreach (var baseCommand in commands)
            {
                BaseTestBlock block = null;
                switch (baseCommand.Command)
                {
                    case "if":
                        block = new IfBlock();
                        break;
                    case "elseif":
                    {
                        var ifBlock = blocks.Peek().As<IfBlock>();
                        ifBlock.AddElseIfBlock();
                        continue;
                    }
                    case "else":
                    {
                        var ifBlock = blocks.Peek().As<IfBlock>();
                        ifBlock.AddElseBlock();
                        continue;
                    }
                    case "while":
                        block = new WhileBlock();
                        break;
                    case "for":
                        block = new ForBlock();
                        break;
                    case "endif":
                    case "endfor":
                    case "endwhile":
                        var b = blocks.Pop();
                        if (!blocks.Any())
                            blockAndCommands.Add(b);
                        continue;
                }

                if (block != null)
                {
                    if (blocks.Any())
                        blocks.Peek().AddBlock(block);
                    blocks.Push(block);
                    continue;
                }

                if (blocks.Any())
                {
                    blocks.Peek().AddCommand(baseCommand);
                    continue;
                }
                blockAndCommands.Add(baseCommand);
            }
        }
    }

    


    public interface ITestBlock
    {
        //void ParseCommand(BaseCommand command);
    }

    public abstract class BaseTestBlock : ITestBlock
    {
        protected readonly IList<BaseCommand> Commands = new List<BaseCommand>();
        protected readonly Queue<BaseTestBlock> Blocks = new Queue<BaseTestBlock>();
        
        public virtual void AddCommand(BaseCommand command)
        {
            Commands.Add(command);
        }

        public virtual void AddBlock(BaseTestBlock testBlock)
        {
            Blocks.Enqueue(testBlock);
        }
        
        public T As<T>() where T : BaseTestBlock
        {
            return (T)this;
        }

        public bool IsStartBlock(BaseCommand command)
        {
            return command.Command.Equals("if") || command.Command.Equals("while") || command.Command.Equals("for");
        }

        public bool IsEndBlock(BaseCommand command)
        {
            return command.Command.Equals("endif") || command.Command.Equals("endWhile") || command.Command.Equals("endfor");
        }
    }
    
    public class IfBlock : BaseTestBlock
    {
        private IfBlock _lastBlock;
        public void AddElseIfBlock()
        {
            base.AddBlock(_lastBlock = new ElseIfBlock());
        }

        public void AddElseBlock()
        {
            base.AddBlock(_lastBlock = new ElseBlock());
        }

        public override void AddCommand(BaseCommand command)
        {
            if (_lastBlock != null)
            {
                _lastBlock.AddCommand(command);
                return;
            }
            base.AddCommand(command);
        }
    }

    public class ElseIfBlock : IfBlock
    {
    }

    public class ElseBlock : IfBlock
    {
    }

    public class WhileBlock : BaseTestBlock
    {
    }

    public class ForBlock : BaseTestBlock
    {
    }
    

    public class BaseCommand
    {
        public BaseCommand(string command)
        {
            Command = command;
        }

        public string Command { get; private set; }
        public override string ToString() => Command;
    }
}