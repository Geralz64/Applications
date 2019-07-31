using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodTest.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }


    public class SimpleRatingAlgorithm : IRatingAlgorithm
    {

        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var results = new RatingResult();

            results.Rating = (int)reviews.Average(r => r.Rating);

            return results;


        }
    }
    public class WeightedAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();

            var counter = 0;

            var total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {

                if (i < reviews.Count() / 2)
                {

                    counter += 2;
                    total += reviews[i].Rating * 2;

                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }

            }

            result.Rating = total / counter;

            return result;


        }


    }







}
