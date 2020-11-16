import { Article } from "../models/article.model";
import { data } from "./seed";

export class ArticleData{
    getData(): Article[]{
        return data.map(v => new Article(v.title,v.description,v.author,v.imageUrl));
    }
}