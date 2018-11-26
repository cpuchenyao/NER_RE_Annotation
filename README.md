# NER_RE_Annotation
## An annotation tool for named entity recognition and relation extraction tasks.

The current tool suports annotation for three kinds of entities and two categories of relation of the three entities. Relation A is for entity 1 and entity 2, and Relation B is for entity 2 and entity 3. More entities or relations can be added or changed in corresponding C# files.

### Instruction:
1. File of Anno.txt should be created at default folder of 'C:/Anno' firstly to store sentences with tags.

2. Once a sentence is annotated, two files of relation annotation will be created automatically in 'C:/Anno' to store relation annotations.

3. Pitch on the words or characters you need to annotate, click the targeted button, corresponding words or characters will be bracketed with '[@#entity_name*]', annotations will be stored in 'C:/Anno/Anno.txt' when clicking the button of 'next setence'.

4. Pitch on the two entities that you think have relations and click on the corresponding relation button, contents will be shown at the below textbox and be stored in the files of 'C:/Anno/entity1_entity2.txt' and 'C:/Anno/entity2_entity3.txt'.




## 用于实体及实体关系抽取的工具

当前版本支持三种实体标注以及三种实体中的两类实体关系标注。关系A对应实体1和实体2，关系B对应实体2和实体3。可以在相应的C#文件中对实体及实体关系进行添加或修改。

### 使用说明

1. 首先需要在C盘新建文件夹Anno，并在其中创建Anno.txt用于存储实体标注；

2. 当一条句子完成标注后，会在文件夹Anno下自动生成存储关系的两个txt文件；

3. 选中拟标注的词或字，点击相应实体按钮，选中的内容将会被括起，例如“[@阿司匹林#药物*]”，点击“下一句”时，内容将会被自动存储于'C:/Anno/Anno.txt'；

4. 分别选中两个实体，点击拟标注的关系按钮，两类关系的内容将会分别在下面的两个文本框中展现，在点击“下一句”时，内容将会分别存储于'C:/Anno/实体1_实体2.txt' and 'C:/Anno/实体2_实体3.txt'
