namespace DuberDinner.Contracts.Menus
{
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        float? AverageRating,
        List<MenuSectionResponse> Sections,
        string HostId,
        List<string> DinnersIds,
        List<string> MenuReviewIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> items);

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description);
}
