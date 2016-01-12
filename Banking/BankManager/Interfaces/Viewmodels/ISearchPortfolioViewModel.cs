namespace Interfaces
{
    public interface ISearchPortfolioViewModel
    {
        IPortfolioDTO SelectedPortfolio{ get; }
        IMediator Mediator { get; set; }
    }
}
