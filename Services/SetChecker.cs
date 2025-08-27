using BuilderCatalogueChallenge.Models.SetModels;
using BuilderCatalogueChallenge.Models.UserModels;

namespace BuilderCatalogueChallenge.Services;

public class SetChecker
{
    public bool CanBuildSet(User user, Set set)
    {
        var setPieces = set.Pieces;
        var userPieces = user.Collection;

        foreach (var setPiece in setPieces)
        {
            if (userPieces == null)
            {
                return false;
            }

            if(!UserHasPiece(setPiece, userPieces))
            {
                return false; // User does not have the required pieces
            }
        }
        return true;
    }

    private bool UserHasPiece(SetPiece setPiece, List<UserPiece> userPieces)
    {
        foreach (var userPiece in userPieces)
        {
            if(userPiece.PieceId == setPiece.Part.DesignId && 
               userPiece.Variants.Any(variant =>
                   variant.Color == setPiece.Part.Material.ToString() &&
                   variant.Count >= setPiece.Quantity))
            {
                return true;
            }
        }
        
        return false; // User does not have the piece
    }
}