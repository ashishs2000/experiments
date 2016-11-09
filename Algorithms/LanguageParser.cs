using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class LanguageParser
    {
        public void Run()
        {
            var commands = new List<BaseCommand>
            {
                new BaseCommand("if"),
                new BaseCommand("select1"),
                new BaseCommand("elseif"),
                new BaseCommand("select2"),
                new BaseCommand("if"),
                new BaseCommand("select3"),
                new BaseCommand("else"),
                new BaseCommand("select4"),
                new BaseCommand("endif"),
                new BaseCommand("endif"),

                new BaseCommand("while"),
                new BaseCommand("if"),
                new BaseCommand("select 12 "),
                new BaseCommand("else"),
                new BaseCommand("select 23"),
                new BaseCommand("endif"),
                new BaseCommand("endwhile"),
            };

            var commandQueue = new CommandQueue(commands);
            commandQueue.Process();
        }
    }

    public class CommandQueue : Queue<BaseCommand>
    {
        private readonly IEnumerable<BaseCommand> _commands;
        public CommandQueue(IEnumerable<BaseCommand> commands)
        {
            _commands = commands;
        }

        public void Process()
        {
            var blockstack = new Stack<BaseBlockCommand>();
            foreach (var baseCommand in _commands)
            {
                BaseBlockCommand blockCommand = null;
                switch (baseCommand.Command)
                {
                    case "if":
                        blockCommand = new IfBlockCommand();
                        break;
                    case "elseif":
                        {
                            var ifBlock = blockstack.Peek().As<IfBlockCommand>();
                            blockCommand = ifBlock.CreateIfElseBlock();
                            break;
                        }
                    case "else":
                        {
                            var ifBlock = blockstack.Peek().As<IfBlockCommand>();
                            blockCommand = ifBlock.CreateElseBlock();
                            break;
                        }
                    case "while":
                        blockCommand = new WhileBlockCommand();
                        break;
                    case "for":
                        blockCommand = new ForBlockCommand();
                        break;
                    case "endif":
                    case "endfor":
                    case "endwhile":
                        while (true)
                        {
                            if(!blockstack.Any())
                                break;

                            blockCommand = blockstack.Pop();
                            if (blockCommand.IsCommandEndTag(baseCommand.Command))
                                break;
                        }

                        if (!blockstack.Any())
                            this.Enqueue(blockCommand);
                        continue;
                }

                if (blockCommand != null)
                {
                    if (blockstack.Any())
                        blockstack.Peek().AddCommand(blockCommand);
                    blockstack.Push(blockCommand);
                    continue;
                }

                if (blockstack.Any())
                {
                    blockstack.Peek().AddCommand(baseCommand);
                    continue;
                }
                this.Enqueue(baseCommand);
            }
        }
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

    public abstract class BaseBlockCommand : BaseCommand
    {
        protected readonly Queue<BaseCommand> Blocks = new Queue<BaseCommand>();
        public abstract bool IsCommandEndTag(string tag);

        protected BaseBlockCommand(string command) : base(command)
        {
        }

        public virtual void AddCommand(BaseCommand command)
        {
            Blocks.Enqueue(command);
        }
        
        public T As<T>() where T : BaseBlockCommand
        {
            return (T)this;
        }
    }
    
    public class IfBlockCommand : BaseBlockCommand
    {   
        private IfBlockCommand _lastBlockCommand;
        public IfBlockCommand() : base("if")
        {
        }

        protected IfBlockCommand(string command) : base(command)
        {
        }

        public ElseIfBlockCommand CreateIfElseBlock()
        {
            var command = new ElseIfBlockCommand();
            _lastBlockCommand = command;
            return command;
        }

        public ElseBlockCommand CreateElseBlock()
        {
            var command = new ElseBlockCommand();
            _lastBlockCommand = command;
            return command;
        }

        public override bool IsCommandEndTag(string tag)
        {
            return tag == "endif";
        }

        public override void AddCommand(BaseCommand command)
        {
            if (_lastBlockCommand != null)
            {
                _lastBlockCommand.AddCommand(command);
                return;
            }
            base.AddCommand(command);
        }
    }

    public class ElseIfBlockCommand : IfBlockCommand
    {
        public ElseIfBlockCommand() : base("elseif")
        {
        }

        public override bool IsCommandEndTag(string tag)
        {
            return false;
        }
    }

    public class ElseBlockCommand : IfBlockCommand
    {
        public ElseBlockCommand() : base("else")
        {
        }

        public override bool IsCommandEndTag(string tag)
        {
            return false;
        }
    }

    public class WhileBlockCommand : BaseBlockCommand
    {
        public WhileBlockCommand() : base("while")
        {
        }

        public override bool IsCommandEndTag(string tag)
        {
            return tag == "endwhile";
        }
    }

    public class ForBlockCommand : BaseBlockCommand
    {
        public ForBlockCommand() : base("for")
        {
        }

        public override bool IsCommandEndTag(string tag)
        {
            return tag == "endfor";
        }
    }
}