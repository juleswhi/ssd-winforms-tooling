// System namespaces
global using System.Reflection;
// FormManager

// Scraper
global using static Scraper.ScrapeType;

// State
global using static StateSystem.StateHelper;
global using static StateSystem.StateType;
global using State = System.Collections.Generic.Dictionary<System.Collections.Generic.IEnumerable<StateSystem.StateType>, object?>;
global using Password = (string Hashed, byte[] Salt);

// Misc
global using static CourseworkTooling.MiscHelper;
global using static CourseworkTooling.ActionHelper;
