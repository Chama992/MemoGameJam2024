# MemoGameJam2024
# 【剧情介绍（包含规则介绍）】
# 1.	剧情简介
# 2.	规则简介
# （1）	场地介绍
# （2）	操纵方式
# （3）	得分方式
# （4）	技能使用
# （5）	注意事项（躲避游走球）
# 【点击开始游戏】
# 【抽选扫帚（鼠标点击选择p1或p2开始抽选）】
# 坐骑种类及buff加成：
# 普通扫帚：无加成，抽取概率50%
# 彗星：最大移速降低百分之2，抽取概率10%
# 光轮2000:最大移速增加百分之2，抽取概率20%
# 光轮2001:加速度提高百分之20，最大移速不变，抽取概率10%
# 火弩箭：加速度提高百分之10，最大移速提高百分之1，抽取概率10%
# 【开始游戏（倒计时3 2 1）】
# 1.场地设计（空间维度）
# 场内有两名玩家，一个鬼飞球，两个游走球，一个金色飞贼，两个球门。球场比例16：9，鬼飞球直径约为球场宽的1/20，游走球比鬼飞球稍小（3/4？），金色飞贼直径为鬼飞球直径1/5。（将玩家设置成圆形，直径鬼飞球直径的3/2）
# 场内存在摩擦力，随速度变化（函数关系参考f=kv）。球门约为鬼飞球直径的5倍。
# 技能形状圆形，大小与鬼飞球差不多（好像不是很重要）。
# 2.移速设计（时间维度）
# 每局时长3分钟，鬼飞球、游走球一直在场，1.5分钟之后金色飞贼开始出现，每隔20秒出先一次，每次出现持续10秒钟，当玩家靠近到一定范围就会快速移动，移速比玩家最大移速小百分之1左右，移动到触发范围外会停止移动。
# 游走球在未触发状态下移速为玩家最大移速的百分之20，当玩家进入一定范围开始触发之后，游走球移速提高至玩家最大移速的百分之200，朝玩家方向发出。
# 3.玩家操纵设计
# 双方从左右两边开始移动，鬼飞球放置球场中央。
# P1；wasd移动，ad提供向前或向后的加速度，ws控制方向，j释放技能
# P2：↑↓←→移动，同上，enter键释放技能。
# 玩家双方在场内移动，撞击鬼飞球进球，同时躲避游走球。进一个鬼飞球得1分。如果玩家被游走球撞击到，反方向弹开一小段距离并眩晕3秒。如果玩家双方撞到，双方均反方向弹开并眩晕3秒。
# 如果30秒内没有球进门（或距离上一次进球间隔30秒），球场随机出现2-3个魔法技能，触碰即可拾取，点击j/enter可释放技能。
# 4.魔法技能设计：
# 隐身：使用技能获得15秒隐身，对方玩家不可见，游走球不可识别。
# 护盾：使用技能获得5秒护盾，与对方玩家、游走球撞击可避免眩晕。
# 攻击：发射子弹，攻击到对方玩家或游走球使其向后弹开一小段距离，该技能可使用3次。子弹存续时长10秒，碰到墙壁回弹，碰到游走球或玩家销毁。
# 比赛过去1.5分钟后放出金色飞贼，玩家触碰到金色飞贼即视为抓取成功，得3分。
# 【游戏结束】
# 3分钟时长用尽，判定比分，比分高者获胜。
