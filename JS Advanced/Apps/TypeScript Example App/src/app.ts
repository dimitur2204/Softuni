import Sammy from "sammy";
import { home } from "./controllers/home";
const app = Sammy('#main');
app.get('#/',home);
app.get('#/home',home);
app.get('/',home);
app.run('#/');