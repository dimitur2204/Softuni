import Sammy from "sammy";
import { home } from "./controllers/home";
var app = Sammy('#main');
app.get('#/', home);
app.get('#/home', home);
app.get('/', home);
app.run('#/');
//# sourceMappingURL=app.js.map