import React, { useContext, useState } from "react";
import { useHistory } from "react-router-dom";
import { PostContext } from "../providers/PostProvider";


const PostForm = () => {
    const { addPost, getAllPosts } = useContext(PostContext);
    const history = useHistory();

    const [isLoading, setIsLoading] = useState(false);
    const [post, setPost] = useState({
        userProfileId: "",
        title: "",
        imageUrl: "",
        caption: "",

    });

    const handleControlledInputChange = (e) => {
        const newPost = { ...post }
        newPost[e.target.id] = e.target.value;
        setPost(newPost);
    }

    const handleClickSavePost = (e) => {
        e.preventDefault()
        setIsLoading(true)

        addPost({
            userProfileId: post.userProfileId,
            title: post.title,
            imageUrl: post.imageUrl,
            caption: post.caption,

        })
            .then(() => {
                getAllPosts()
                setPost({
                    userProfileId: "",
                    title: "",
                    imageUrl: "",
                    caption: "",
                })
            })
    }


    return (
        <>
            <form className="postForm">
                <div className="title">
                    <h2 className="postForm__title">New Gif!</h2>
                </div>
                <div className="text">
                    <fieldset>
                        <div className="form-group">
                            <label htmlFor="userProfileId">User Profile Id:</label>
                            <input type="text" id="userProfileId" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="User Id" value={post.userProfileId} />
                        </div>
                    </fieldset>
                    <fieldset>
                        <div className="form-group">
                            <label htmlFor="title">Gif Title:</label>
                            <input type="text" id="title" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Gif Title" value={post.title} />
                        </div>
                    </fieldset>
                    <fieldset>
                        <div className="form-group">
                            <label htmlFor="imageUrl">Image Url:</label>
                            <input type="text" id="imageUrl" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Image Url" value={post.imageUrl} />
                        </div>
                    </fieldset>
                    <fieldset>
                        <div className="form-group">
                            <label htmlFor="caption">Caption:</label>
                            <input type="text" id="caption" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Caption" value={post.caption} />
                        </div>
                    </fieldset>
                </div>
                <button className="btn btn-primary" disabled={isLoading} onClick={handleClickSavePost}>
                    Save Gif!
          </button>
            </form>
        </>

    )
}
export default PostForm;