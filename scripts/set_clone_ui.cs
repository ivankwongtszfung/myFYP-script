﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductObject
{
    public int pid;
    public string cat_name;
    public string name;
    public string model_name;
    public string description;
    public string cost;

}
public class MyProduct
{
    public string status;
    public ProductObject[] product;
    public static MyProduct CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MyProduct>(jsonString);
    }
}

public class set_clone_ui : MonoBehaviour
{
    private MyProduct json = new MyProduct();

    void Start()
    {
        string productData = "{\"product\":[{\"pid\":1,\"cat_name\":\"table\",\"model_name\":\"CoffeTable_2\",\"name\":\"Black Coffee Table\",\"description\":\"This is a black coffee table with a metal base.\",\"cost\":\"350.00\"},{\"pid\":2,\"cat_name\":\"sofa\",\"model_name\":\"Pref_Sofa2_Cotton\",\"name\":\"Black Cotton Sofa\",\"description\":\"A good black cotton sofa with some red pillows.\",\"cost\":\"3500.00\"},{\"pid\":3,\"cat_name\":\"chair\",\"model_name\":\"chair_3\",\"name\":\"Black Single Sofa\",\"description\":\"A metal base, black cotton single sofa.\",\"cost\":\"500.00\"},{\"pid\":4,\"cat_name\":\"chair\",\"model_name\":\"Armchair\",\"name\":\"Gray Armchair\",\"description\":\"This is a gray armchair.\",\"cost\":\"510.00\"},{\"pid\":5,\"cat_name\":\"bed\",\"model_name\":\"Bed\",\"name\":\"Gray Leather Bed\",\"description\":\"Best bed for matching a gray style bedroom.\",\"cost\":\"4280.00\"},{\"pid\":6,\"cat_name\":\"chair\",\"model_name\":\"relax\",\"name\":\"Relax Chair\",\"description\":\"A chair that makes you relax.\",\"cost\":\"539.00\"},{\"pid\":7,\"cat_name\":\"storage\",\"model_name\":\"sek1\",\"name\":\"Wood Wardrobe\",\"description\":\"Can put lots of clothes inside.\",\"cost\":\"2130.00\"},{\"pid\":8,\"cat_name\":\"table\",\"model_name\":\"Bed Desk Type 2\",\"name\":\"Wood Nightstand\",\"description\":\"A dark wood nightstand with two drawers.\",\"cost\":\"689.00\"},{\"pid\":9,\"cat_name\":\"storage\",\"model_name\":\"TV Shell\",\"name\":\"Gray TV Shell\",\"description\":\"This is a gray tv shell.\",\"cost\":\"784.00\"},{\"pid\":10,\"cat_name\":\"table\",\"model_name\":\"table_2\",\"name\":\"Wood Glass Table\",\"description\":\"Good for dining room or study room.\",\"cost\":\"2468.00\"},{\"pid\":11,\"cat_name\":\"chair\",\"model_name\":\"Chair_7\",\"name\":\"White Wooden Chiar\",\"description\":\"A wooden chair with a white back and seat.\",\"cost\":\"244.00\"},{\"pid\":12,\"cat_name\":\"chair\",\"model_name\":\"wickerchair\",\"name\":\"Wicker Chair\",\"description\":\"A chair composed of wood and wicker.\",\"cost\":\"316.00\"},{\"pid\":13,\"cat_name\":\"chair\",\"model_name\":\"Chair_8\",\"name\":\"Light Blue Wooden Chair\",\"description\":\"A wooden chair with a light blue seat.\",\"cost\":\"272.00\"},{\"pid\":14,\"cat_name\":\"chair\",\"model_name\":\"classicwood_yellow\",\"name\":\"Classical Wood Chair\",\"description\":\"A dark wooden chair, which iis classical of the classical.\",\"cost\":\"243.00\"},{\"pid\":15,\"cat_name\":\"bed\",\"model_name\":\"bed\",\"name\":\"Japanese Style Low Wooden Bed\",\"description\":\"This is a Japanese style low wooden bed.\",\"cost\":\"5340.00\"},{\"pid\":16,\"cat_name\":\"bed\",\"model_name\":\"bed2\",\"name\":\"Red Double Bed\",\"description\":\"This is a red double bed without stand.\",\"cost\":\"4621.00\"},{\"pid\":17,\"cat_name\":\"bed\",\"model_name\":\"bed1\",\"name\":\"Flower Double Bed\",\"description\":\"This is a flower style double bed.\",\"cost\":\"4560.00\"},{\"pid\":18,\"cat_name\":\"bed\",\"model_name\":\"Queen_Bed_2\",\"name\":\"Queen Double Bed\",\"description\":\"This is a queen style double bed.\",\"cost\":\"5690.00\"},{\"pid\":19,\"cat_name\":\"chair\",\"model_name\":\"Chair_5\",\"name\":\"Blue Dining Chair\",\"description\":\"This is a Blue dining chair.\",\"cost\":\"512.00\"},{\"pid\":20,\"cat_name\":\"chair\",\"model_name\":\"chair\",\"name\":\"Blue Tisu Chair\",\"description\":\"This is a blue chair made with tisu.\",\"cost\":\"489.00\"},{\"pid\":21,\"cat_name\":\"table\",\"model_name\":\"DressingTable Type5\",\"name\":\"Wooden Dressing Table\",\"description\":\"This is a wooden dressing table wiht a mirror.\",\"cost\":\"990.00\"},{\"pid\":22,\"cat_name\":\"chair\",\"model_name\":\"Chair_2\",\"name\":\"Orange Chair\",\"description\":\"This is a orange chair with a round metal base.\",\"cost\":\"524.00\"},{\"pid\":23,\"cat_name\":\"storage\",\"model_name\":\"cabinet_1\",\"name\":\"Dark Wooden Cabinet\",\"description\":\"This is a dark wooden cabinet with 4 doors and 3 barrels.\",\"cost\":\"2690.00\"},{\"pid\":24,\"cat_name\":\"table\",\"model_name\":\"kitchn_table_1\",\"name\":\"Wooden Kitchen Table\",\"description\":\"This is a wooden kitchen table.\",\"cost\":\"2314.00\"},{\"pid\":25,\"cat_name\":\"storage\",\"model_name\":\"bar_counter\",\"name\":\"Wooden Bar Counter\",\"description\":\"This is a wooden bar counter.\",\"cost\":\"2421.00\"},{\"pid\":26,\"cat_name\":\"storage\",\"model_name\":\"Kitchen_Cabinet_1\",\"name\":\"Gray Kitchen Cabinet\",\"description\":\"This is a gray kitchen cabinet.\",\"cost\":\"4192.00\"},{\"pid\":27,\"cat_name\":\"storage\",\"model_name\":\"BookCase_1\",\"name\":\"Wooden Book Case\",\"description\":\"This is a wooden book case.\",\"cost\":\"712.00\"},{\"pid\":28,\"cat_name\":\"table\",\"model_name\":\"table_1\",\"name\":\"Wooden Desk\",\"description\":\"This is a wooden desk with 6 barrels.\",\"cost\":\"2146.00\"},{\"pid\":29,\"cat_name\":\"table\",\"model_name\":\"table_3\",\"name\":\"Small Wooden Desk\",\"description\":\"This is a small wooden desk wihth 4 barrels.\",\"cost\":\"1980.00\"},{\"pid\":30,\"cat_name\":\"chair\",\"model_name\":\"Chair_6\",\"name\":\"Wooden School Chair\",\"description\":\"This is a wooden school chair.\",\"cost\":\"389.00\"},{\"pid\":31,\"cat_name\":\"chair\",\"model_name\":\"officeChair\",\"name\":\"Office Chair\",\"description\":\"This is an office chair.\",\"cost\":\"512.00\"},{\"pid\":32,\"cat_name\":\"chair\",\"model_name\":\"Chair_03_1\",\"name\":\"Brown Bag Chair\",\"description\":\"This is a brown bag chair.\",\"cost\":\"421.00\"},{\"pid\":33,\"cat_name\":\"chair\",\"model_name\":\"Chair_03_2\",\"name\":\"Yellow Bag Chair\",\"description\":\"This is a yellow bag chair.\",\"cost\":\"421.00\"},{\"pid\":34,\"cat_name\":\"chair\",\"model_name\":\"Chair_1\",\"name\":\"Wooden Arm Chair\",\"description\":\"This is a wooden arm chair.\",\"cost\":\"486.00\"},{\"pid\":35,\"cat_name\":\"table\",\"model_name\":\"coffee_table_4\",\"name\":\"Wooden Circle Coffee Table\",\"description\":\"This is a wooden circlular shape coffee table.\",\"cost\":\"381.00\"},{\"pid\":36,\"cat_name\":\"sofa\",\"model_name\":\"Couch_3\",\"name\":\"Gray Couch\",\"description\":\"This is a gray couch.\",\"cost\":\"3260.00\"},{\"pid\":37,\"cat_name\":\"table\",\"model_name\":\"coffee_table_4\",\"name\":\"Wooden Circlular Coffee Table\",\"description\":\"This is a wooden circlular coffee table.\",\"cost\":\"381.00\"},{\"pid\":38,\"cat_name\":\"sofa\",\"model_name\":\"sofa2\",\"name\":\"Orange Single Sofa\",\"description\":\"This is an orange single sofa with a coussin.\",\"cost\":\"1840.00\"},{\"pid\":39,\"cat_name\":\"sofa\",\"model_name\":\"sofa1\",\"name\":\"Black Double Sofa\",\"description\":\"This is a black double sofa with two coussins.\",\"cost\":\"3920.00\"},{\"pid\":40,\"cat_name\":\"table\",\"model_name\":\"Coffe_table\",\"name\":\"Steel Rectangle Coffee Table\",\"description\":\"This is a rectangle coffee table which is made of steel.\",\"cost\":\"412.00\"},{\"pid\":41,\"cat_name\":\"table\",\"model_name\":\"Coffe_table (1)\",\"name\":\"Steel Square Coffee Table\",\"description\":\"This is a rectangle coffee table which is made of steel.\",\"cost\":\"379.00\"},{\"pid\":42,\"cat_name\":\"storage\",\"model_name\":\"tv_shelf\",\"name\":\"Wooden Wall Mount TV Shelf\",\"description\":\"This is a wooden wall mount TV shelf.\",\"cost\":\"2890.00\"},{\"pid\":43,\"cat_name\":\"storage\",\"model_name\":\"shkaf 2 m\",\"name\":\"Window Cabinet\",\"description\":\"This is a cabinet with two windows.\",\"cost\":\"1125.00\"},{\"pid\":44,\"cat_name\":\"storage\",\"model_name\":\"cabinet_2\",\"name\":\"Green Lake Cabinet\",\"description\":\"This is a green lake cabinet with a display stand.\",\"cost\":\"3140.00\"},{\"pid\":45,\"cat_name\":\"table\",\"model_name\":\"Bed Desk Type 2 (1)\",\"name\":\"Black Marble NightStand\",\"description\":\"A black marble nightstand with two drawers.\",\"cost\":\"409.00\"},{\"pid\":46,\"cat_name\":\"chair\",\"model_name\":\"Lounge Chair One\",\"name\":\"Lounge Chair\",\"description\":\"This is a lounge chair.\",\"cost\":\"789.00\"},{\"pid\":47,\"cat_name\":\"table\",\"model_name\":\"desk\",\"name\":\"Modern Desk\",\"description\":\"This a modern desk in white color.\",\"cost\":\"1123.00\"},{\"pid\":48,\"cat_name\":\"chair\",\"model_name\":\"woodstool_yellow\",\"name\":\"Wood Stool\",\"description\":\"This is a wood stool.\",\"cost\":\"358.00\"},{\"pid\":49,\"cat_name\":\"storage\",\"model_name\":\"Dresser\",\"name\":\"Wooden Dresser\",\"description\":\"This is a wooden dresser.\",\"cost\":\"1590.00\"}],\"status\":\"success\"}";
        json = MyProduct.CreateFromJSON(productData);
        Debug.Log(json.product);
    }

}