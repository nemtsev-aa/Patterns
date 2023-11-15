public interface IUIPanelVisitor {
    void Visit(UIPanel panel);
    void Visit(GamePanel game);
    void Visit(ShopPanel shop);
    void Visit(WinPanel win);
}
