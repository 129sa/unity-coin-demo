<img width="936" height="375" alt="image" src="https://github.com/user-attachments/assets/ed7c84d9-1ac5-4c0e-8bc1-f1042ed4fa5c" /># Unity 金币收集 Demo

一个练习 Unity 完整链路的 3D 小原型：角色控制 → 物理碰撞 → 触发器拾取 → UI 计数 → 协程刷新。

## 演示

<img width="936" height="375" alt="image" src="https://github.com/user-attachments/assets/c34b93e7-e8fe-49ff-ba6b-d17582ae7390" />


## 功能

- **角色控制**：WASD 移动（跟随角色朝向）、鼠标视角（俯仰限制 ±60°）、空格跳跃（重力积分、落地判定）
- **物理碰撞**：Rigidbody + Collider，`OnCollisionEnter` 检测落地
- **触发器拾取**：`isTrigger` + `CompareTag("Player")` + `Destroy`
- **UI**：UGUI 金币计数、按钮交互
- **协程**：拾取后金币 3 秒原地刷新

## 技术要点

- 用 transform.forward / transform.right 做自身坐标系移动，避免角色转向后方向错乱
- 斜向输入 `normalized`，防止 W+D 速度变成 √2 倍
- 缓存 `Camera.main` 与组件引用，避免 `Update` 里反复查找
- 协程用 WaitForSeconds 实现延迟刷新，不阻塞主线程

## 运行方式

1. Unity 2022.3 LTS / 团结引擎 1.6.x 打开工程
2. 打开 Assets/Scenes/【场景名】.unity
3. 点击 Play

## 环境

- 引擎：团结引擎 1.6.11（Unity 2022.3 LTS 内核）
- 语言：C#
